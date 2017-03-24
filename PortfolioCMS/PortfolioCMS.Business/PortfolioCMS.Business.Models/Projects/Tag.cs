using System.ComponentModel.DataAnnotations;
using PortfolioCMS.Business.Common.Constants;

namespace PortfolioCMS.Business.Models.Projects
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.TagNameMinLength)]
        [MaxLength(ValidationConstants.TagNameMaxLength)]
        public string Title { get; set; }
    }
}
