using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Domain.Entities
{
    [Table("departments")]
    public class Department : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Employee>? Employees { get; set; }

        [Column("manager_id")]
        public long? ManagerId { get; set; }
    }
}
