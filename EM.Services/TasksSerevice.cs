using EM.Data;
using EM.Domain.Entities;
using EM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EM.Services
{
    public class TasksSerevice : ITasksSerevice
    {
        private readonly Repository<EMContext> db;

        public TasksSerevice(IRepository<EMContext> repository)
        {
            db = (Repository<EMContext>)repository;
        }
        public async Task Add(Domain.Entities.Job entity)
        {
            db.Add<Job>(entity);
            await db.SaveAync();
        }

        public async Task Delete(long id)
        {
            var entity = this.Get(id);

            if (entity != null)
            {
                await db.DeleteAsync<Job>(entity);
            }
            else
            {
                throw new Exception("The Job you ment to delete dosen't exist");
            }
        }

        public bool Exists(long id)
        {
            return this.Get(id) != null;
        }

        public IEnumerable<Job> Get()
        {
            return db.GetList<EM.Domain.Entities.Job>();
        }

        public Job? Get(long id)
        {
            return db.Get<Job>(e => e.Id == id);
        }

        public IEnumerable<Job> GetBy(Expression<Func<Job, bool>> predicate)
        {
            return db.GetList<Job>(predicate);
        }

        public void Update(Job entity)
        {
            try
            {
                db.Update(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }
    }
}
