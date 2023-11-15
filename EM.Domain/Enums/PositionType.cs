using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EM.Domain.Enums
{
    public enum PositionType
    {
        [Display(Name = "N/A")]
        NONE,
        [Display(Name = "Coder")]
        CODER,
        [Display(Name = "Programmer")]
        PROGRAMMER,
        [Display(Name = "Full-Stack Developer")]
        FULL_STACK_DEVELOPER,
        [Display(Name = "Server Developer")]
        SERVER_DEVELOPER,
        [Display(Name = "UI Developer")]
        UI_DEVELOPER,
        [Display(Name = "Designer")]
        DESIGNER,
        [Display(Name = "Architect")]
        ARCHITECT
    }
}
