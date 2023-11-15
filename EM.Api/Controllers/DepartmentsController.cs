using EM.Domain.Entities;
using EM.Domain.Enums;
using EM.Domain.Helpers;
using EM.Domain.Interfaces;
using EM.Domain.ViewModels;
using EM.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmetsService _service;

        public DepartmentsController(IDepartmetsService service)
        {
            _service = (DepartmetsService)service;
        }


        [HttpGet]
        public ActionResult<IEnumerable<DepartmentViewModel>> Get()
        {
            var Departments = _service.Get().Select(e =>
            {
                //string managerName = string.Empty;
                //if (e.ManagerID != null && e.Employees != null && e.Employees.Count > 0)
                //{
                //    var employee = e.Employees.First(x => x.ID == e.ManagerID);
                //    managerName = $"{employee.FirstName} {employee.LastName}";
                //}
                return new DepartmentViewModel
                {
                    ID = e.Id,
                    Name = e.Name,
                    //ManagerID = e.ManagerID,
                    //ManagerName = managerName
                };
            }).ToList();

            return Ok(JsonConvert.SerializeObject(Departments));
        }


        [HttpGet("{id}")]
        public ActionResult<Department> Get(long id)
        {
            var Department = _service.Get(id);

            if (Department == null)
            {
                return NotFound();
            }

            return Ok(Department);
        }


        [HttpPut("{id}")]
        public IActionResult Put(long id, Department model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!_service.Exists(id))
            {
                return NotFound();
            }

            try
            {
                _service.Update(model);
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult> Post(DepartmentViewModel model)
        {
            try
            {
                await _service.Add(new Department()
                {
                    Name = model.Name
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }


            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
