using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Models.Projects;
using PortfolioCMS.Business.Services.Projects;

namespace PortfolioCMS.Business.Data.Tests.DbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void HaveParameterlessConstructor()
        {
            // Arrange
            var context = new PortfolioCmsDbContext();

            // Act & Assert
            Assert.IsInstanceOf<PortfolioCmsDbContext>(context);
        }

        [Test]
        public void Return_InstanceOfIPortfolioCmsDbContext()
        {
            // Arrange
            var context = new PortfolioCmsDbContext();

            // Act & Assert
            Assert.IsInstanceOf<IPortfolioCmsDbContext>(context);
        }        
    }
}
