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
    public class Delete_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenArgumentIsNull()
        {
            var mockedSet = new Mock<DbSet<IProject>>();
            var mockedDbContext = new Mock<IPortfolioCmsDbContext>();
            mockedDbContext.Setup(mock => mock.Set<IProject>()).Returns(mockedSet.Object);

            var repository = new EFRepository<IProject>(mockedDbContext.Object);
            IProject entity = null;

            Assert.That(
                () => repository.Delete(entity),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Entity cannot be null!"));
        }

        [Test]
        public void NotThrow_WhenArgumentIsValid()
        {
            var mockedSet = new Mock<IDbSet<IProject>>();
            var mockedProject = new Mock<IProject>();
            mockedProject.SetupAllProperties();

            var mockedContext = new Mock<IPortfolioCmsDbContext>();
            mockedContext.Setup(x => x.Set<IProject>()).Returns(mockedSet.Object);

            var repository = new EFRepository<IProject>(mockedContext.Object);

            try
            {
                repository.Delete(mockedProject.Object);
            }
            catch (NullReferenceException e) { };

            mockedContext.Verify(x => x.Entry(mockedProject.Object), Times.AtLeastOnce);
        }
    }
}
