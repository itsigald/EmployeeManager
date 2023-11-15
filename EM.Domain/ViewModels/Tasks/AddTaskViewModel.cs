using Newtonsoft.Json;

namespace EM.Domain.ViewModels.Tasks
{
    public class AddTaskViewModel
    {
        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("dueDate")]
        public DateTime DueDate { get; set; }

        [JsonProperty("assignDate")]
        public DateTime AssignedDate { get; set; } = DateTime.Now;

        [JsonProperty("employeeId")]
        public long EmployeeID { get; set; }
    }
}
