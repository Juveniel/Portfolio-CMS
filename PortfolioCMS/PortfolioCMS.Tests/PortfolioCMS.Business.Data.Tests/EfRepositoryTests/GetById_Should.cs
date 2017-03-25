using System.Data.Entity;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Data.Repositories;
using PortfolioCMS.Business.Models.Projects.Contracts;

namespace PortfolioCMS.Business.Data.Tests.EfRepositoryTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnCorrectResult_WhenParameterIsValid()
        {
            var mockedDbSet = new Mock<DbSet<IProject>>();
            var mockedDbContext = new Mock<IPortfolioCmsDbContext>();
            mockedDbContext.Setup(mock => mock.Set<IProject>()).Returns(mockedDbSet.Object);

            var repository = new EFRepository<IProject>(mockedDbContext.Object);

            var fakeProject = new Mock<IProject>();
            mockedDbSet.Setup(x => x.Find(It.IsAny<int>())).Returns(fakeProject.Object);

            var validId = 15;
            Assert.That(repository.GetById(validId), Is.Not.Null);
            Assert.AreEqual(repository.GetById(validId), fakeProject.Object);
        }
    }
}
