using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PortfolioCMS.Business.Common.Constants;
using PortfolioCMS.Business.Common.Enumerations;
using PortfolioCMS.Business.Models.Projects.Contracts;

namespace PortfolioCMS.Business.Models.Projects
{
    public class Project : IProject
    {
        private ICollection<Comment> comments;
        private ICollection<Image> images;
        private ICollection<Tag> tags;

        public Project()
        {
            this.comments = new HashSet<Comment>();
            this.images = new HashSet<Image>();
            this.tags = new HashSet<Tag>();
        }    

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.ProjectNameMinLength)]
        [MaxLength(ValidationConstants.ProjectNameMaxLength)]
        public string Title { get; set; }

        [MinLength(ValidationConstants.ProjectNameMinLength)]
        [MaxLength(ValidationConstants.ProjectNameMaxLength)]
        public string Subtitle { get; set; }

        [Required]
        [MinLength(ValidationConstants.ProjectDescriptionMinLength)]
        [MaxLength(ValidationConstants.ProjectDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public DateTime DateStarted { get; set; }

        [Required]
        public DateTime DateFinished { get; set; }

        [Required]
        public ProjectCategory Category { get; set; }

        public string DemoUrl { get; set; }

        public DateTime Published { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }

            set { this.comments = value; }
        }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }

            set { this.images = value; }
        }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }

            set { this.tags = value; }
        }
    }
}
