using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Models;
using PortfolioCMS.Business.Models.Users;

namespace PortfolioCMS.Business.Data
{
    public class PortfolioCmsDbContext : IdentityDbContext<ApplicationUser>, IPortfolioCmsDbContext
    {    
        public PortfolioCmsDbContext()
            : base("PortfolioCMS", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Admin> Car { get; set; }

        public static PortfolioCmsDbContext Create()
        {
            return new PortfolioCmsDbContext();
        }
            
        IDbSet<T> IPortfolioCmsDbContext.Set<T>()
        {
            return base.Set<T>();
        }

        void IPortfolioCmsDbContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
