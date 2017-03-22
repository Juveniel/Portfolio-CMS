using System.Data.Entity.Migrations;

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
        }
    }
}
