using EM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain.Entities
{
    [Table("employees")]
    public class Employee : BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; } = string.Empty;

        [Column("last_name")]
        public string LsstName { get; set; } = string.Empty;

        [Column("position")]
        public PositionType Position { get; set; }

        [Column("department_id")]
        public long DepartmentId { get; set; }
        public virtual Department? Department { get; set; }


        [Column("manager_id")]
        public long? ManagerId { get; set; }
        public virtual Employee? Manager { get; set; }

        public virtual ICollection<Job>? Tasks { get; set; } = default;
    }
}
