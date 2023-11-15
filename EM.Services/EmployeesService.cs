using EM.Data;
using EM.Domain.Entities;
using EM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EM.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly Repository<EMContext> db;

        public EmployeesService(IRepository<EMContext> repository)
        {
            db = (Repository<EMContext>)repository;
        }

        public async Task Add(Employee entity)
        {
            db.Add<Employee>(entity);
            await db.SaveAync();
        }

        public async Task Delete(long id)
        {
            var entity = this.Get(id);
            if (entity != null)
            {
                await db.DeleteAsync<Employee>(entity);
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

        public IEnumerable<Employee> Get()
        {
            return db.GetList<Employee>();
        }

        public Employee? Get(long id)
        {
            // .Include(a => ((a.Child == null) ? new Collection<Child>() : a.Child));
            // .Include(p=>p.Child).Where(p=>p.Child!=null).ToList();
            // (t as Derived).MyProperty'

            //return db.GetList<Employee>(x => x.Id == id)
            //    //.Include(e => (Employee)e.Manager)
            //    .FirstOrDefault();

            return db.Get<Employee>(e => e.Id == id);
        }

        public IEnumerable<Employee> GetBy(Expression<Func<Employee, bool>> predicate)
        {
            return db.GetList<Employee>(predicate);
        }

        public void Update(Employee entity)
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