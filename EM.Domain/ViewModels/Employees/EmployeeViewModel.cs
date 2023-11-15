using EM.Domain.Entities;
using EM.Domain.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Domain.ViewModels
{
    public class EmployeeViewModel
    {
        [JsonProperty("id")]
        public long ID { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonProperty("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonProperty("position")]
        public PositionType Position { get; set; } = PositionType.NONE;

        [JsonProperty("positionName")]
        public string PositionName { get; set; } = string.Empty;

        [JsonProperty("departmentId")]
        public long DepartmentId { get; set; }

        [JsonProperty("departmentName")]
        public string? DepartmentName { get; set; } = string.Empty;

        [JsonProperty("tasks")]
        public List<TaskViewModel>? Tasks { get; set; } = null;

        [JsonProperty("managerId")]
        public long? ManagerId { get; set; }
    }
}
