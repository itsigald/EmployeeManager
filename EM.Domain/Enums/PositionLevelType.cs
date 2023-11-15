using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain.Enums
{
    public enum PositionLevelType
    {
        [Display(Name = "Jonior")]
        JONIOR,

        [Display(Name = "Senior")]
        SENIOR,
        
        [Display(Name = "Expert")]
        EXPERT,
        
        [Display(Name = "Leader")]
        LEADER
    }
}
