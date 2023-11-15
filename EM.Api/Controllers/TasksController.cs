using EM.Domain.Interfaces;
using EM.Domain.ViewModels.Tasks;
using EM.Services;
using Microsoft.AspNetCore.Mvc;

namespace EM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly TasksSerevice _tasksService;

        public TasksController(ITasksSerevice tasks)
        {
            _tasksService = (TasksSerevice)tasks;
        }

        [HttpPost]
        public ActionResult Post(AddTaskViewModel model)
        {
            _tasksService.Add(new Domain.Entities.Job()
            {
                Text = model.Text,
                AssignedDate = DateTime.Now,
                DueDate = model.DueDate,
                EmployeeID = model.EmployeeID,
                Status = Domain.Enums.TaskStatusType.NEW
            });
            return Ok();
        }
    }
}
