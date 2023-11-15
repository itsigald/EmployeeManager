using Newtonsoft.Json;

namespace EM.Domain.ViewModels
{
    public class DepartmentViewModel
    {
        [JsonProperty("id")]
        public long ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("managerId")]
        public long? ManagerID { get; set; } = null;

        [JsonProperty("managerName")]
        public string? ManagerName { get; set; } = string.Empty;
    }
}
