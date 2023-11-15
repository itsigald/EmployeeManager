using EM.Data;
using EM.Domain.Entities;
using EM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EM.Services
{
    public class ReportsService : IReportsService
    {
        private readonly Repository<EMContext> db;

        public ReportsService(IRepository<EMContext> repository)
        {
            db = (Repository<EMContext>)repository;
        }
        public async Task Add(Report entity)
        {
            db.Add<Report>(entity);
            await db.SaveAync();
        }

        public async Task Delete(long id)
        {
            var entity = this.Get(id);

            if (entity != null)
            {
                await db.DeleteAsync<Report>(entity);
            }
            else
            {
                throw new Exception("The item you ment to delete dosen't exist");
            }
        }

        public bool Exists(long id)
        {
            return this.Get(id) != null;
        }

        public IEnumerable<Report> Get()
        {
            return db.GetList<Report>().ToList();
        }

        public Report? Get(long id)
        {
            return db.Get<Report>(e => e.Id == id);
        }

        public IEnumerable<Report> GetBy(Expression<Func<Report, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Report entity)
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
