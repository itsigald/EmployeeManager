using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain.Entities
{
    public class BaseEntity
    {
        [ScaffoldColumn(false)]
        [Key]
        [Column("id")]
        public long Id { get; set; }
    }
}
