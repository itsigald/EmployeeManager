using EM.Domain.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Domain.Entities
{
    [Table("employees")]
    public class Employee : BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; } = string.Empty;

        [Column("larst_name")]
        public string LastName { get; set; } = string.Empty;

        [Column("position")]
        public PositionType Position { get; set; }

        [Column("department_id")]
        public long? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        [Column("manager_id")]
        public long? ManagerId { get; set; }
        public Employee? Manager { get; set; }

        public virtual ICollection<Job>? Tasks { get; set; } = default;
    }
}
