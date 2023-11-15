using EM.Domain.Entities;
using EM.Domain.Enums;
using EM.Domain.General;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EM.Domain.Interfaces
{
    public interface IRepository<C> where C : DbContext
    {
        void Add<T>(T entity) where T : class;
        bool Any<T>(Expression<Func<T, bool>> predicate) where T : class;
        int Count<T>(Expression<Func<T, bool>> predicate) where T : class;
        T? Get<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> GetList<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBy) where T : class;
        IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate, OrderByType orderByType, Expression<Func<T, TKey>> orderBy) where T : class;
        IQueryable<T> GetList<T, TKey>(Expression<Func<T, TKey>> orderBy) where T : class;
        IQueryable<T> GetList<T, TKey>(OrderByType orderByType, Expression<Func<T, TKey>> orderBy) where T : class;
        IQueryable<T> GetList<T>() where T : class;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : class;
        void Delete<T>(Expression<Func<T, bool>> predicate) where T : class;
        System.Threading.Tasks.Task DeleteAsync<T>(T entity) where T : class;
        void DeleteAll<T>(ICollection<T> collection) where T : class;
        System.Threading.Tasks.Task DeleteAllAsync<T>(ICollection<T> collection) where T : class;
        OperationStatus Save(string message);
        Task<OperationStatus> SaveAync(string message);
        void Dispose();
    }
}
