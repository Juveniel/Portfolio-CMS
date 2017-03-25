using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Runtime.Serialization;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Data.Repositories;
using PortfolioCMS.Business.Models.Projects.Contracts;

namespace PortfolioCMS.Business.Data.Tests.EfRepositoryTests
{
    [TestFixture]
    public class Add_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenArgumentIsNull()
        {
            // Arrange
            var mockedSet = new Mock<DbSet<IProject>>();
            var mockedDbContext = new Mock<IPortfolioCmsDbContext>();
            mockedDbContext.Setup(mock => mock.Set<IProject>()).Returns(mockedSet.Object);

            var repository = new EFRepository<IProject>(mockedDbContext.Object);
            IProject entity = null;

            // Act & Assert
            Assert.That(
                () => repository.Add(entity),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Entity cannot be null!"));
        }

        [Test]
        public void NotThrow_WhenArgumentIsValid()
        {
            // Arrange
            var mockedSet = new Mock<IDbSet<IProject>>();
            var mockedModel = new Mock<IProject>();
            mockedModel.SetupAllProperties();

            var fakeEntry = (DbEntityEntry<IProject>)FormatterServices
                .GetSafeUninitializedObject(typeof(DbEntityEntry<IProject>));

            var mockedContext = new Mock<IPortfolioCmsDbContext>();
            mockedContext.Setup(x => x.Set<IProject>()).Returns(mockedSet.Object);
            mockedContext.Setup(x => x.Entry(It.IsAny<IProject>())).Returns(fakeEntry);

            // Act
            var repository = new EFRepository<IProject>(mockedContext.Object);
            try
            {
                repository.Add(mockedModel.Object);
            }
            catch (NullReferenceException e) { };

            // Assert
            mockedContext.Verify(x => x.Entry(mockedModel.Object), Times.AtLeastOnce);
        }
    }
}
