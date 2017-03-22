using System.Linq;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity.EntityFramework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Models;
using PortfolioCMS.Business.Models.Users;
using PortfolioCMS.Business.Services.Account.Contracts;

namespace PortfolioCMS.Business.Services.Account
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IEFRepository<IdentityRole> userRolesRepository;
        private readonly IEFRepository<Admin> adminRepository;
        private readonly IUnitOfWork unitOfWork;

        public RegistrationService(
            IEFRepository<IdentityRole> userRolesRepository,
            IEFRepository<Admin> adminRepository,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(userRolesRepository, "userRolesRepo").IsNull().Throw();
            Guard.WhenArgument(adminRepository, "adminRepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.userRolesRepository = userRolesRepository;
            this.adminRepository = adminRepository;
            this.unitOfWork = unitOfWork;
        }


        public IQueryable<IdentityRole> GetAllUserRoles()
        {
            return this.userRolesRepository.All();
        }

        public ApplicationUser CreateApplicationUser(string email)
        {
            Guard.WhenArgument(email, "email").IsNullOrEmpty().Throw();

            ApplicationUser newUser = new ApplicationUser()
            {
                UserName = email,
                Email = email
            };

            return newUser;
        }

        public void CreateAdmin(string adminId)
        {
            Guard.WhenArgument(adminId, "adminId").IsNullOrEmpty().Throw();

            using (var uow = this.unitOfWork)
            {
                var admin = new Admin()
                {
                    Id = adminId
                };

                this.adminRepository.Add(admin);

                uow.SaveChanges();
            }
        }
    }
}
