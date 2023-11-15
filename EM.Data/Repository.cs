using EM.Domain.Entities;
using EM.Domain.Enums;
using EM.Domain.General;
using EM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using OperationStatus = EM.Domain.General.OperationStatus;

namespace EM.Data
{
    public class Repository<C> : IDisposable, IRepository<C> where C : EMContext, new()
    {
        private C? dataContext;

        //private static object addEntityObject = new();

        private readonly IConfiguration _config;

        public Repository(IConfiguration config)
        {
            _config = config;
        }

        public virtual C DataContext
        {
            get
            {
                if (dataContext == null)
                {
                    dataContext = new C
                    {
                        ConnectionString = _config.GetConnectionString("default")
                    };
                }

                return dataContext;
            }
        }

        public void Add<T>(T entity) where T : class
        {
            DataContext.Set<T>().Add(entity);
        }

        public bool Any<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return DataContext.Set<T>().Any(predicate);
        }

        public int Count<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return DataContext.Set<T>().Count(predicate);
        }

        public T? Get<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return DataContext.Set<T>().Where(predicate).SingleOrDefault(); 
        }

        public IQueryable<T> GetList<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return DataContext.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBy) where T : class
        {
            return GetList(predicate, OrderByType.Ascending, orderBy);
        }

        public IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate, OrderByType orderByType, Expression<Func<T, TKey>> orderBy) where T : class
        {
            if (orderByType == OrderByType.Ascending)
            {
                return GetList(predicate).OrderBy(orderBy);
            }
            else
            {
                return GetList(predicate).OrderByDescending(orderBy);
            }
        }

        public IQueryable<T> GetList<T, TKey>(Expression<Func<T, TKey>> orderBy) where T : class
        {
            return GetList<T, TKey>(OrderByType.Ascending, orderBy);
        }

        public IQueryable<T> GetList<T, TKey>(OrderByType orderByType, Expression<Func<T, TKey>> orderBy) where T : class
        {
            if (orderByType == OrderByType.Ascending)
            {
                return GetList<T>().OrderBy(orderBy);
            }
            else
            {
                return GetList<T>().OrderBy(orderBy);
            }
        }

        public IQueryable<T> GetList<T>() where T : class
        {
            return DataContext.Set<T>();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            var entry = DataContext.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {
                var set = DataContext.Set<T>();
                T? attachedEntity = set.Find(entity.Id);

                if (attachedEntity != null)
                {
                    var attachedEntry = DataContext.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }

        public void Delete<T>(T entity) where T : class
        {
            DataContext.Set<T>().Remove(entity);
        }

        public void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            T? entity = Get<T>(predicate);

            if (entity != null)
            {
                this.Delete<T>(entity);
            }
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            await System.Threading.Tasks.Task.Run(() => Delete<T>(entity));
        }

        public void DeleteAll<T>(ICollection<T> collection) where T : class
        {
            DbSet<T> dbSet = DataContext.Set<T>();
            collection.ToList<T>().ForEach(x => dbSet.Remove(x));
        }

        public async Task DeleteAllAsync<T>(ICollection<T> collection) where T : class
        {
            await System.Threading.Tasks.Task.Run(() => DeleteAll(collection));
        }

        public OperationStatus Save(string? message = null)
        {
            OperationStatus operationStatus = new();

            try
            {
                DataContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                operationStatus.Status = false;
                operationStatus.Message = message;
                operationStatus.Exception = e;
                return operationStatus;
            }

            return operationStatus;
        }

        public async Task<OperationStatus> SaveAync(string? message = null)
        {
            OperationStatus operationStatus = new();

            try
            {
                await DataContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                operationStatus.Status = false;
                operationStatus.Message = message;
                operationStatus.Exception = exception;
                return operationStatus;
            }

            return operationStatus;
        }

        public void Dispose()
        {
            DataContext?.Dispose();
        }
    }
}
