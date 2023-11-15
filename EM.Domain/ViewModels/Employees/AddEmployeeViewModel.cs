using EM.Domain.Enums;
using Newtonsoft.Json;

namespace EM.Domain.ViewModels
{
    public class AddEmployeeViewModel
    {

        [JsonProperty("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonProperty("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonProperty("position")]
        public string? Position { get; set; }

        [JsonProperty("departmentId")]
        public long? DepartmentId { get; set; } = default;

        [JsonProperty("managerId")]
        public long? ManagerId { get; set; } = default;
    }
}