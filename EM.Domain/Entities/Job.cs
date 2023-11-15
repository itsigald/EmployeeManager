using EM.Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain.Entities
{
    [Table("tasks")]
    public class Job: BaseEntity
    {
        [Column("text")]
        [Required]
        public string? Text { get; set; }

        [Column("due_date")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DueDate { get; set; } = DateTime.Now;

        [Column("assign_date")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime AssignedDate { get; set; } = DateTime.Now;

        [Column("status")]
        [Required]
        public TaskStatusType Status { get; set; } = TaskStatusType.NONE;

        [Column("employee_id")]
        public long? EmployeeID { get; set; } = default;
        public virtual Employee? Employee { get; set; }

    }
}
