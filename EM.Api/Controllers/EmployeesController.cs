using EM.Domain.Entities;
using EM.Domain.Enums;
using EM.Domain.Helpers;
using EM.Domain.Interfaces;
using EM.Domain.ViewModels;
using EM.Domain.ViewModels.Employees;
using EM.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace EM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesService _employeeService;
        private readonly DepartmetsService _departmetsService;
        private readonly TasksSerevice _tasksService;

        public EmployeesController(IEmployeesService employees, IDepartmetsService departmets, ITasksSerevice tasks)
        {
            _employeeService = (EmployeesService)employees;
            _departmetsService = (DepartmetsService)departmets;
            _tasksService = (TasksSerevice)tasks;
        }


        [HttpGet]
        public ActionResult<IEnumerable<EmployeeViewModel>> Get()
        {
            //var departments = _departmetsService.Get().ToDictionary(x => x.Id, x => x.Name);

            var employees = _employeeService.Get().Select(e => new EmployeeViewModel
            {
                ID = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Position = e.Position,
                PositionName = EnumHelper<PositionType>.GetDisplayValue(e.Position),
                DepartmentId = e.DepartmentId.GetValueOrDefault(),
                ManagerId = e.ManagerId,
            }).ToList();



            return Ok(employees);
        }

        [HttpGet]
        [Route("/api/employees/view/{id}")]
        public ActionResult<ViewEmployeeViewModel> GetView(long id)
        {
            Employee? employee = _employeeService.Get(id);

            if (employee == null)
            {
                return NotFound();
            }

            long managerId = employee.ManagerId.GetValueOrDefault();

            long departmentId = employee.DepartmentId.GetValueOrDefault();

            var result = new ViewEmployeeViewModel()
            {
                ID = id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position,
                PositionName = EnumHelper<PositionType>.GetDisplayValue(employee.Position),
                ManagerId = managerId,
                DepartmentId = departmentId,
            };

            if (departmentId != default)
            {
                var department = _departmetsService.Get(departmentId);
                result.DepartmentName = department?.Name;
            }

            if (managerId != default)
            {
                var manager = _employeeService.Get(managerId);

                if(manager != null)
                {
                    result.ManagerName = $"{manager.FirstName} {manager.LastName}";
                }
            }

            result.Tasks = _tasksService.GetBy(x => x.EmployeeID == id).Select(t => new TaskViewModel()
            {
                Text = t.Text,
                AssignedDate = t.AssignedDate,
                DueDate = t.DueDate,
                EmployeeID = id,
                Status=t.Status,
            }).ToList();

            result.Subordinates = _employeeService.GetBy(x => x.ManagerId == id).Select(s => new EmployeeViewModel()
            {
                ID = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Position = s.Position,
                PositionName = EnumHelper<PositionType>.GetDisplayValue(s.Position),
                DepartmentId = s.DepartmentId.GetValueOrDefault(),
            }).ToList();

            return Ok(result);
        }


        [HttpGet("{id}")]
        public ActionResult<EmployeeViewModel> Get(long id)
        {
            var employee = _employeeService.Get(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(new EmployeeViewModel()
            {
                ID = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position,
                PositionName = EnumHelper<PositionType>.GetDisplayValue(employee.Position),
                DepartmentId = employee.DepartmentId.GetValueOrDefault(),
            });
        }


        [HttpPut("{id}")]
        public IActionResult Put(long id, Employee model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!_employeeService.Exists(id))
            {
                return NotFound();
            }

            try
            {
                _employeeService.Update(model);
            }
            catch (Exception)
            {
                throw;
            }

            return Ok();
        }


        [HttpPost]
        public async Task<ActionResult> Post(AddEmployeeViewModel model)
        {
            await _employeeService.Add(new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Position = EnumHelper<PositionType>.Parse(value: ((model.Position != null && model.Position != string.Empty) ? model.Position : "0")),
                DepartmentId = model.DepartmentId,
                ManagerId = model.ManagerId,
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _employeeService.Delete(id);
            return Ok();
        }
    }
}
