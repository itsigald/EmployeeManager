using EM.Domain.Enums;
using Newtonsoft.Json;

namespace EM.Domain.ViewModels.Employees
{
    public class ViewEmployeeViewModel
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

        [JsonProperty("managerName")]
        public string? ManagerName { get; set; } = string.Empty;

        [JsonProperty("managerId")]
        public long ManagerId { get; set; }

        [JsonProperty("tasks")]
        public List<TaskViewModel>? Tasks { get; set; } = null;

        [JsonProperty("tasks")]
        public List<EmployeeViewModel>? Subordinates { get; set; } = null;

    }
}
