using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Models.Projects;
using PortfolioCMS.Business.Services.Projects;

namespace PortfolioCMS.Business.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class Dispose_Should
    {
        [Test]
        public void BeDisposedCorrectly()
        {
            var mockRepository = new Mock<IEFRepository<Project>>();
            var mockUow = new Mock<IUnitOfWork>();

            var service = new ProjectService(mockRepository.Object, mockUow.Object);

            using (var uw = mockUow.Object)
            {
                var projects = service.GetAllProjects();
            }

            mockUow.Verify(m => m.Dispose(), Times.Exactly(1));
        }

        [TestFixture]
        public class DisposeShould
        {
            [Test]
            public void NotBeCalled_WhenOutsideUsingBlock()
            {
                var dbContext = new Mock<IPortfolioCmsDbContext>();

                var unitOfWork = new UnitOfWork.UnitOfWork(dbContext.Object);
                unitOfWork.Dispose();

                dbContext.Verify(u => u.Dispose(), Times.Never);
            }
        }
    }
}
