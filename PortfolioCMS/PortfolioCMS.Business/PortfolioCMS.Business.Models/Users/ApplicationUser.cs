using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PortfolioCMS.Business.Common.Constants;
using PortfolioCMS.Business.Models.Projects;

namespace PortfolioCMS.Business.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Project> projects;

        public ApplicationUser()
        {
            this.projects = new HashSet<Project>();
        }

        [MinLength(ValidationConstants.NameMinLength)]
        [MaxLength(ValidationConstants.NameMaxLength)]
        public string FirstName { get; set; }

        [MinLength(ValidationConstants.NameMinLength)]
        [MaxLength(ValidationConstants.NameMaxLength)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string AvatarUrl { get; set; }

        public virtual ICollection<Project> Projects
        {
            get { return this.projects; }

            set { this.projects = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}
