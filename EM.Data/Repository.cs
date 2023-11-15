using EM.Domain.Entities;
using EM.Domain.Enums;
using EM.Domain.General;
using EM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EM.Data
{
    public class Repository<R> : IDisposable, IRepository<R> where R : DbContext, new()
    {
        private R? dataContext;

        private static readonly object addEntityObject = new object();

        public virtual R DataContext
        {
            get 
            {
                if(dataContext == null)
                    dataContext = new R();

                return dataContext; 
            }
        }

        public virtual void Add<T>(T entity) where T : class
        {
            DataContext.Set<T>().Add(entity);
        }

        public virtual void Add<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual int Count<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return DataContext.Set<T>().Count(predicate);
        }

        public virtual T? Get<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return DataContext.Set<T>().Where(predicate).SingleOrDefault();
        }

        public virtual IQueryable<T> GetList<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return DataContext.Set<T>().Where(predicate);
        }

        public virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBy) where T : class
        {
            return GetList(predicate, OrderByType.Ascending, orderBy);
        }

        public virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate, OrderByType orderByType, Expression<Func<T, TKey>> orderBy) where T : class
        {
            if(orderByType == OrderByType.Ascending)
            {
                return GetList(predicate).OrderBy(orderBy);
            }
            else
            {
                return GetList(predicate).OrderByDescending(orderBy);
            }
        }

        public virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, TKey>> orderBy) where T : class
        {
            return GetList<T, TKey>(OrderByType.Ascending, orderBy);
        }

        public virtual IQueryable<T> GetList<T, TKey>(OrderByType orderByType, Expression<Func<T, TKey>> orderBy) where T : class
        {
            if (orderByType == OrderByType.Ascending)
                return GetList<T>().OrderBy(orderBy);
            else
                return GetList<T>().OrderByDescending(orderBy);
        }

        public virtual IQueryable<T> GetList<T>() where T : class
        {
            return DataContext.Set<T>();
        }

        public virtual void Update<T>(T entity) where T : BaseEntity
        {
            var entry = DataContext.Entry<T>(entity);

            if(entry.State == EntityState.Detached)
            {
                var set = DataContext.Set<T>();
                T? attachedEntity = set.Find(entity.Id);

                if(attachedEntity != null)
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

        public virtual void Delete<T>(T entity) where T : class
        {
            DataContext.Set<T>().Remove(entity);
        }

        public virtual void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            T? entity = this.Get<T>(predicate);

            if(entity != null)
            {
                this.Delete<T>(entity);
            }
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            await Task.Run(() =>
            {
                Delete<T>(entity);
            });
        }

        public virtual void DeleteAll<T>(ICollection<T> collection) where T : class
        {
            DbSet<T> dbSet = DataContext.Set<T>();
            collection.ToList<T>().ForEach(x => dbSet.Remove(x));
        }

        public async Task DeleteAllAsync<T>(ICollection<T> collection) where T : class
        {
            await Task.Run(() =>
            {
                DeleteAll<T>(collection);
            });
        }

        public virtual OperationStatus Save(string message)
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

        public async Task<OperationStatus> SaveAync(string message)
        {
            OperationStatus operationStatus = new();

            try
            {
                await DataContext.SaveChangesAsync();
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

        public void Dispose()
        {
            if (DataContext != null)
            {
                DataContext.Dispose();
            }
        }
    }
}
