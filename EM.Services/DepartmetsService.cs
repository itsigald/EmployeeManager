using EM.Data;
using EM.Domain.Entities;
using EM.Domain.Interfaces;
using System.Linq.Expressions;

namespace EM.Services
{
    public class DepartmetsService : IDepartmetsService
    {
        private readonly IRepository<EMContext> _repository;

        public DepartmetsService(IRepository<EMContext> repository)
        {
            _repository = repository;
        }

        public void Add(Department entity)
        {
            try
            {
                _repository.Add<Department>(entity);
                _repository.Save("Error on save Department entity");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            var entity = this.Get(id);

            if(entity != null)
            {
                _repository.Delete<Department>(entity);
            }
            else
            {
                throw new Exception($"The Department with id {id} dosen't exist");
            }
        }

        public bool Exists(long id)
        {
            return this.Get(id) != null;
        }

        public IEnumerable<Department> Get()
        {
            return _repository.GetList<Department>();
        }

        public Department? Get(long id)
        {
            return _repository.Get<Department>(k => k.Id == id);
        }

        public IEnumerable<Department> GetBy(Expression<Func<Department, bool>> predicate)
        {
            return _repository.GetList<Department>(predicate);
        }

        public void Update(Department entity)
        {
            try
            {
                _repository.Update<Department>(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
