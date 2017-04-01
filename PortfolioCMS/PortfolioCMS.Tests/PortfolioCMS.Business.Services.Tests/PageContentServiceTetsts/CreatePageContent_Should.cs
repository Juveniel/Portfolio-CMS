using System;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Models.Content;
using PortfolioCMS.Business.Services.PageContents;

namespace PortfolioCMS.Business.Services.Tests.PageContentServiceTetsts
{
    [TestFixture]
    public class CreatePageContent_Should
    {
        [Test]
        public void BeInvoked_WhenPageContentIsValid()
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);
            var validContent = new Mock<PageContent>();

            //Act
            pageContentService.CreatePageContent(validContent.Object);

            //Assert
            mockedRepository.Verify(repository => repository.Add(validContent.Object));
        }

        [Test]
        public void BeInvokeOnce_WhenParamsAreCorrect()
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);
            var validContent = new Mock<PageContent>();

            //Act
            pageContentService.CreatePageContent(validContent.Object);

            //Assert
            mockedRepository.Verify(repository => repository.Add(It.IsAny<PageContent>()), Times.Once);
        }

        [Test]
        public void CallSaveChangesOnce_WhenPageContentIsValid()
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);
            var validContent = new Mock<PageContent>();

            //Act
            pageContentService.CreatePageContent(validContent.Object);

            //Assert
            mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
        }

        [Test]
        public void ThrowException_WhenPageContentIsInvalid()
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);

            Mock<PageContent> contentToAdd = null;

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => pageContentService.CreatePageContent(contentToAdd.Object));
        }
    }
}
