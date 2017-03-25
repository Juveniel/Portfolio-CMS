using System;
using System.Data.Entity;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Data.Repositories;
using PortfolioCMS.Business.Models.Projects.Contracts;

namespace PortfolioCMS.Business.Data.Tests.EfRepositoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenIPetsWonderlandDbContextIsNull()
        {
            // Arrange              
            IPortfolioCmsDbContext nullContext = null;

            // Act & Assert
            Assert.That(
                () => new EFRepository<IProject>(nullContext),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Db context is null!"));
        }

        [Test]
        public void ShouldWorkCorrectly_WhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<IPortfolioCmsDbContext>();
            var mockedModel = new Mock<DbSet<IProject>>();
            mockedContext.Setup(x => x.Set<IProject>()).Returns(mockedModel.Object);

            // Act
            var repository = new EFRepository<IProject>(mockedContext.Object);

            // Assert
            Assert.That(repository, Is.Not.Null);
        }

        [Test]
        public void ShouldSetContextCorrectly_WhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<IPortfolioCmsDbContext>();
            var mockedModel = new Mock<DbSet<IProject>>();
            mockedContext.Setup(x => x.Set<IProject>()).Returns(mockedModel.Object);

            // Act
            var repository = new EFRepository<IProject>(mockedContext.Object);

            // Assert
            Assert.That(repository.Context, Is.Not.Null);
            Assert.That(repository.Context, Is.EqualTo(mockedContext.Object));
        }

        [Test]
        public void ShouldSetDbSetCorrectly_WhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<IPortfolioCmsDbContext>();
            var mockedModel = new Mock<DbSet<IProject>>();
            mockedContext.Setup(x => x.Set<IProject>()).Returns(mockedModel.Object);

            // Act
            var repository = new EFRepository<IProject>(mockedContext.Object);

            // Assert
            Assert.That(repository.DbSet, Is.Not.Null);
            Assert.That(repository.DbSet, Is.EqualTo(mockedModel.Object));
        }

        [Test]
        public void Testtt()
        {
            // Arrange
            var mockedContext = new Mock<IPortfolioCmsDbContext>();
            var mockedModel = new Mock<DbSet<IProject>>();
            mockedContext.Setup(x => x.Set<IProject>()).Returns(mockedModel.Object);

            // Act
            var repository = new EFRepository<IProject>(mockedContext.Object);

            // Assert
            Assert.That(repository.DbSet, Is.Not.Null);
            Assert.That(repository.DbSet, Is.EqualTo(mockedModel.Object));
        }
    }
}
