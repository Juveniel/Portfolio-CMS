using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;

namespace PortfolioCMS.Business.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class SaveChanges_Should
    {
        [Test]
        public void InvokeDbContextOnce()
        {
            var mockedContext = new Mock<IPortfolioCmsDbContext>();
            var unitOfWork = new UnitOfWork.UnitOfWork(mockedContext.Object);

            unitOfWork.SaveChanges();

            mockedContext.Verify(mock => mock.SaveChanges(), Times.Once());
        }
    }
}
