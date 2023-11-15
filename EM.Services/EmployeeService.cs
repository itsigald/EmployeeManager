using EM.Data;
using EM.Domain.Entities;
using EM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EM.Services
{
    public class EmployeeService : IEmployeesService
    {
        private readonly IRepository<EMContext> _repository;
        
        public EmployeeService(IRepository<EMContext> repository)
        {
            _repository = repository;
        }

        public void Add(Employee entity)
        {
            try
            {
                _repository.Add<Employee>(entity);
                _repository.Save("Error on save Employee entity");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            var entity = this.Get(id);

            if (entity != null)
            {
                _repository.Delete<Employee>(entity);
            }
            else
            {
                throw new Exception($"The Employee with id {id} dosen't exist");
            }
        }

        public bool Exists(long id)
        {
            return this.Get(id) != null;
        }

        public IEnumerable<Employee> Get()
        {
            return _repository.GetList<Employee>();
        }

        public Employee? Get(long id)
        {
            return _repository.Get<Employee>(k => k.Id == id);
        }

        public IEnumerable<Employee> GetBy(Expression<Func<Employee, bool>> predicate)
        {
            return _repository.GetList<Employee>(predicate);
        }

        public void Update(Employee entity)
        {
            try
            {
                _repository.Update<Employee>(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
