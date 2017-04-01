using System;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Models.Content;
using PortfolioCMS.Business.Services.PageContents;

namespace PortfolioCMS.Business.Services.Tests.PageContentServiceTetsts
{
    [TestFixture]
    public class UpdatePageContent_Should
    {
        [Test]
        public void BeCalled_IfIsValid()
        {
            // Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);
            var contentToUpdate = new Mock<PageContent>();

            // Act
            pageContentService.UpdatePageContent(contentToUpdate.Object);

            // Assert
            mockedRepository.Verify(rep => rep.Update(contentToUpdate.Object), Times.Once);
        }

        [Test]
        public void ThrowNullReferenceException_IfNull()
        {
            // Arrange & Act
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object); 
            Mock<PageContent> nullContent = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => pageContentService.UpdatePageContent(nullContent.Object));
        }

        [Test]
        public void CallSaveChanges_IfValid()
        {
            // Arrange & Act
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);
            var content = new Mock<PageContent>();

            // Act
            pageContentService.UpdatePageContent(content.Object);

            // Assert
            mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
        }
    }
}
