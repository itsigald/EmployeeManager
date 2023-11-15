using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain.Enums
{
    public enum TaskStatusType
    {
        [Display(Name = "N/A")]
        NONE,

        [Display(Name = "New")]
        NEW,
        
        [Display(Name = "Ready For Dev")]
        READY,
        
        [Display(Name = "In Progress")]
        IN_PROGRESS,
        
        [Display(Name = "Closed")]
        CLOSED
    }
}
