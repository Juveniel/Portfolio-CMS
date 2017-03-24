using System.ComponentModel.DataAnnotations;

namespace PortfolioCMS.Business.Common.Enumerations
{
    public enum ProjectCategory
    {
        [Display(Name = "Front-end")]
        FrontEnd = 1,
        Backend = 2,
        [Display(Name = "UX Design")]
        UxDesign = 3,
    }
}