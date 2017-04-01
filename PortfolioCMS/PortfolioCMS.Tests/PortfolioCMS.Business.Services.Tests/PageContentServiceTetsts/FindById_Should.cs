using System;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Models.Content;
using PortfolioCMS.Business.Services.PageContents;

namespace PortfolioCMS.Business.Services.Tests.PageContentServiceTetsts
{
    [TestFixture]
    public class FindById_Should
    {
        [Test]
        public void WorksProperly_WhenInvoked()
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);
            var content = new Mock<PageContent>();

            //Act
            mockedRepository.Setup(repository => repository.GetFirst(x => x.Id == content.Object.Id))
                .Returns(content.Object);

            //Assert
            Assert.AreEqual(pageContentService.FindById(content.Object.Id), It.IsAny<PageContent>());
        }

        [Test]
        public void ReturnCorrectPageContent_WhenInvoked()
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);
            var content = new Mock<PageContent>();

            //Act
            var contentToCompare = new Mock<PageContent>();
            mockedRepository.Setup(repository => repository.GetFirst(x => x.Id == content.Object.Id))
                .Returns(() => content.Object);

            Assert.AreNotEqual(pageContentService.FindById(content.Object.Id), contentToCompare.Object);
        }

        [TestCase(123123)]
        [TestCase(123123322)]
        public void ReturnNull_WhenNoPageContentFound(int testId)
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            mockedRepository.Setup(repository => repository.GetFirst(x => x.Id == testId))
                .Returns(() => null);

            //Assert
            Assert.IsNull(pageContentService.FindById(testId));
        }

        [Test]
        public void ThrowException_WhenNullPageContent()
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            Mock<PageContent> content = null;

            //Assert
            Assert.Throws<NullReferenceException>(() => pageContentService.FindById(content.Object.Id));
        }
    }
}
