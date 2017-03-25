using System;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;

namespace PortfolioCMS.Business.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenDbContextParameterIsNull()
        {
            IPortfolioCmsDbContext nullContext = null;

            Assert.That(
                () => new UnitOfWork.UnitOfWork(nullContext),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Db context is null!"));
        }

        [Test]
        public void ShouldWork_WhenParametersAreValid()
        {
            var mockDbContext = new Mock<IPortfolioCmsDbContext>();

            var uow = new UnitOfWork.UnitOfWork(mockDbContext.Object);

            Assert.IsNotNull(uow);
        }

        [Test]
        public void CreateUowThatImplementsIDisposableAndIUnitOfWork_WhenParametersAreValid()
        {
            var mockDbContext = new Mock<IPortfolioCmsDbContext>();

            var uow = new UnitOfWork.UnitOfWork(mockDbContext.Object);

            Assert.IsInstanceOf<IDisposable>(uow);
            Assert.IsInstanceOf<IUnitOfWork>(uow);
        }
    }
}
