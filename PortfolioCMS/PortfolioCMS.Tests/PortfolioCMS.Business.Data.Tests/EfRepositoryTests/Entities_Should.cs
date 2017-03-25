using System.Data.Entity;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Data.Repositories;
using PortfolioCMS.Business.Models.Projects.Contracts;

namespace PortfolioCMS.Business.Data.Tests.EfRepositoryTests
{
    [TestFixture]
    public class Entities_Should
    {
        [Test]
        public void ReturnTheCorrectDbSet()
        {
            var mockedContext = new Mock<IPortfolioCmsDbContext>();
            var mockedSet = new Mock<IDbSet<IProject>>();

            mockedContext.Setup(x => x.Set<IProject>()).Returns(mockedSet.Object);

            var repository = new EFRepository<IProject>(mockedContext.Object);

            Assert.NotNull(repository.Entities);
            Assert.IsInstanceOf(typeof(IDbSet<IProject>), repository.Entities);
            Assert.AreSame(repository.Entities, repository.DbSet);
        }
    }
}
