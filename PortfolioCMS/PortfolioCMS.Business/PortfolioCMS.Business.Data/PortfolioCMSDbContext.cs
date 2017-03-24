using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Models;
using PortfolioCMS.Business.Models.Content;
using PortfolioCMS.Business.Models.Projects;

namespace PortfolioCMS.Business.Data
{
    public class PortfolioCmsDbContext : IdentityDbContext<ApplicationUser>, IPortfolioCmsDbContext
    {    
        public PortfolioCmsDbContext()
            : base("PortfolioCMS", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<PageContent> Sections { get; set; }

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
