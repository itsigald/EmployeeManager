using Newtonsoft.Json;

namespace EM.Domain.ViewModels.Reports
{
    public class AddReportViewModel
    {
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;

        [JsonProperty("managerId")]
        public long ManagerId { get; set; }

        [JsonProperty("employeeId")]
        public long EmployeeId { get; set; }
    }
}
