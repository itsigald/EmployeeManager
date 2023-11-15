using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain.Entities
{
    [Table("departements")]
    public class Department : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("manager_id")]
        public long? ManagerId { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
