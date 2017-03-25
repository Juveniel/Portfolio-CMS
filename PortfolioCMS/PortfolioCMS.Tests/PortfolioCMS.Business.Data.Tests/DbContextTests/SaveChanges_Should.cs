using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Models.Projects;
using PortfolioCMS.Business.Services.Projects;

namespace PortfolioCMS.Business.Data.Tests.DbContextTests
{
    [TestFixture]
    public class SaveChanges_Should
    {
        [Test]
        public void SaveChanges_ShouldWorkCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IEFRepository<Project>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var projectService = new ProjectService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            projectService.AddProject(new Project());

            // Assert
            mockedUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
