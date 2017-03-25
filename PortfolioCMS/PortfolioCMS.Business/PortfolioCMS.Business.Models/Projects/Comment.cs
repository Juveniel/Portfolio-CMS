using System;
using System.ComponentModel.DataAnnotations;
using PortfolioCMS.Business.Common.Constants;
using PortfolioCMS.Business.Models.Projects.Contracts;

namespace PortfolioCMS.Business.Models.Projects
{
    public class Comment : IComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.CommentMinLength)]
        [MaxLength(ValidationConstants.CommentMaxLength)]
        public string Content { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public string Author { get; set; }                 
    }
}
