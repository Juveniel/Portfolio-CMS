using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PortfolioCMS.Business.Common.Constants;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Data.Repositories;
using PortfolioCMS.Business.Models;
using PortfolioCMS.Business.Models.Content;

namespace PortfolioCMS.Business.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<PortfolioCmsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PortfolioCmsDbContext context)
        {
            this.SeedRoles(context);
            this.SeedAdminUser(context);
            SeedTestPageContent(context);
        }

        private void SeedRoles(PortfolioCmsDbContext context)
        {
            if (context.Roles.Any())
            {
                return;                
            }

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var adminRole = new IdentityRole { Name = UserRoles.Administrator };

            roleManager.Create(adminRole);
        }

        private void SeedAdminUser(PortfolioCmsDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            bool hasAdminUser = context.Users.Any(u => u.UserName == "admin");
        
            if (!hasAdminUser)
            {
                var admin = new ApplicationUser { UserName = "admin", Email = "admin@example.com" };

                userManager.Create(admin, WebConfigurationManager.AppSettings["AdminPassword"]);
                userManager.AddToRole(admin.Id, UserRoles.Administrator);
            }
        }

        private void SeedTestPageContent(PortfolioCmsDbContext context)
        {
            var page = new PageContent
            {
                SectionName = "About Me",
                Title = "About Me section alabala",
                Content = "Lorem ipsum dolor sit amet  ipsum dolor sit amet v ipsum dolor sit amet ipsum dolor sit amet"
            };


            var repo = new EFRepository<PageContent>(context);
            repo.Add(page);

            var uow = new UnitOfWork.UnitOfWork(context);

            using (var tt = uow)
            {
                tt.SaveChanges();
            }
        }
    }
}
