using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PortfolioCMS.Business.Data;

namespace PortfolioCMS.Business.Identity
{
	public class ApplicationRoleManager : RoleManager<IdentityRole>
	{
		public ApplicationRoleManager(IRoleStore<IdentityRole, string> store)
			: base(store)
		{
		}

		public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
		{
			var roleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<PortfolioCmsDbContext>()));

			const string AdminRole = "Admin";

			if (roleManager.Roles.Any())
			{
				return roleManager;
			}

			roleManager.Create(new IdentityRole(AdminRole));

			return roleManager;
		}
	}
}