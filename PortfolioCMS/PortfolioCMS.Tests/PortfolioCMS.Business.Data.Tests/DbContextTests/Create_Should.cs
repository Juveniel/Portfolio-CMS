using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;

namespace PortfolioCMS.Business.Data.Tests.DbContextTests
{
    [TestFixture]
    class Create_Should
    {
        [Test]
        public void ShouldReturnNewDbContextInstance()
        {
            // Arrange & Act
            var newContext = PortfolioCmsDbContext.Create();

            // Assert
            Assert.IsNotNull(newContext);
            Assert.IsInstanceOf<IPortfolioCmsDbContext>(newContext);

        }
    }
}
