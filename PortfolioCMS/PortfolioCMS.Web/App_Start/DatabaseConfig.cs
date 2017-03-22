using System.Data.Entity;
using PortfolioCMS.Business.Data;
using PortfolioCMS.Business.Data.Migrations;

namespace PortfolioCMS.Web.App_Start
{
    public class DatabaseConfig
    {
        public static void Config()
        {
            // Initialize database
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PortfolioCmsDbContext, Configuration>());
        }
    }
}