using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EM.Domain.Enums;

namespace EM.Domain.ViewModels
{
    public class TaskViewModel
    {
        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("dueDate")]
        public DateTime DueDate { get; set; }

        [JsonProperty("assignDate")]
        public DateTime AssignedDate { get; set; } // = DateTime.Now;.ToString(format: "yyyy-MM-ddTHH:mm:ss");

        [JsonProperty("status")]
        public TaskStatusType Status { get; set; } = TaskStatusType.NONE;

        [JsonProperty("employeeId")]
        public long EmployeeID { get; set; }
    }
}
