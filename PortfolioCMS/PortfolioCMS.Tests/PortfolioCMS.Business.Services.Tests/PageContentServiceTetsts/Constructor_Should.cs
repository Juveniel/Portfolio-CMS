using System;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Models.Content;
using PortfolioCMS.Business.Services.PageContents;

namespace PortfolioCMS.Business.Services.Tests.PageContentServiceTetsts
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateDestinationService_WhenParamsAreValid()
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act & Assert
            Assert.That(pageContentService, Is.InstanceOf<PageContentService>());
        }

        [Test]
        public void ThrowNullException_WhenRepositoryIsNull()
        {
            //Arrange
            Mock<IEFRepository<PageContent>> mockedRepository = null;
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object));
        }

        [Test]
        public void ThrowNullException_WhenUnitofworkIsNull()
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            Mock<IUnitOfWork> mockedUnitOfWork = null;

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object));
        }
    }
}
