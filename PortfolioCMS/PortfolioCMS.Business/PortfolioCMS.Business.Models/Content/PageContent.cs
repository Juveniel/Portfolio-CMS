using System.ComponentModel.DataAnnotations;
using PortfolioCMS.Business.Common.Constants;

namespace PortfolioCMS.Business.Models.Content
{
    public class PageContent
    {
        public int Id { get; set; }

        [Required]
        public string SectionName { get; set; }

        [Required]
        [MinLength(ValidationConstants.PageContentNameMinLength)]
        [MaxLength(ValidationConstants.PageContentNameMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstants.PageContentDescriptionMinLength)]
        [MaxLength(ValidationConstants.PageContentDescriptionMaxLength)]
        public string Content { get; set; }
        
        public string Image { get; set; }
    }
}
