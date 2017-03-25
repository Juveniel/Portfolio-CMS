using System.ComponentModel.DataAnnotations;
using PortfolioCMS.Business.Common.Constants;
using PortfolioCMS.Business.Models.Projects.Contracts;

namespace PortfolioCMS.Business.Models.Projects
{
    public class Tag : ITag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.TagNameMinLength)]
        [MaxLength(ValidationConstants.TagNameMaxLength)]
        public string Title { get; set; }
    }
}
