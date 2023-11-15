using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain.Entities
{
    [Table("reports")]
    public class Report : BaseEntity
    {
        [Required]
        [Column("text")]
        public string Text { get; set; } = string.Empty;

        [Required]
        [Column("date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Column("manager_id")]
        public long ManagerId { get; set; }

        [Column("employee_id")]
        public long EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
