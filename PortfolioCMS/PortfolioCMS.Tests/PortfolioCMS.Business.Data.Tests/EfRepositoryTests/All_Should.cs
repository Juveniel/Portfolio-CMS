using System.Data.Entity;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Data.Repositories;
using PortfolioCMS.Business.Models.Projects.Contracts;

namespace PortfolioCMS.Business.Data.Tests.EfRepositoryTests
{
    [TestFixture]
    public class All_Should
    {
        [Test]
        public void ReturnEntitiesOfThisSet()
        {
            var mockedContext = new Mock<IPortfolioCmsDbContext>();
            var mockedSet = new Mock<IDbSet<IProject>>();

            mockedContext.Setup(x => x.Set<IProject>()).Returns(mockedSet.Object);

            var repository = new EFRepository<IProject>(mockedContext.Object);

            Assert.NotNull(repository.All());
            Assert.IsInstanceOf(typeof(IDbSet<IProject>), repository.All());
            Assert.AreSame(repository.All(), repository.DbSet);
        }
    }
}
