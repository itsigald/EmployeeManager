using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

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
