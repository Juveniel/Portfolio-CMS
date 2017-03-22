using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using PortfolioCMS.Business.Models;

namespace PortfolioCMS.Business.Services.Account.Contracts
{
    public interface IRegistrationService
    {
        IQueryable<IdentityRole> GetAllUserRoles();

        ApplicationUser CreateApplicationUser(string email);

        void CreateAdmin(string adminId);
    }
}