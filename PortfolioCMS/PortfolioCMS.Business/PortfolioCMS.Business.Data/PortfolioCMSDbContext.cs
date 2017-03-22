using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Models;

namespace PortfolioCMS.Business.Data
{
    public class PortfolioCmsDbContext : IdentityDbContext<ApplicationUser>, IPortfolioCmsDbContext
    {    
        public PortfolioCmsDbContext()
            : base("PortfolioCmsDb")
        {
        }

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
