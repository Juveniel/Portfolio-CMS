using System;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Models.Content;
using PortfolioCMS.Business.Services.PageContents;

namespace PortfolioCMS.Business.Services.Tests.PageContentServiceTetsts
{
    [TestFixture]
    public class FindBySectionName_Should
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
            mockedRepository.Setup(repository => repository.GetFirst(x => x.SectionName == content.Object.SectionName))
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
            mockedRepository.Setup(repository => repository.GetFirst(x => x.SectionName == content.Object.SectionName))
                .Returns(() => content.Object);

            Assert.AreNotEqual(pageContentService.FindById(content.Object.Id), contentToCompare.Object);
        }

        [TestCase("Test")]
        [TestCase("Testasdad2")]
        public void ReturnNull_WhenNoPageContentFound(string testSectionName)
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            mockedRepository.Setup(repository => repository.GetFirst(x => x.SectionName == testSectionName))
                .Returns(() => null);

            //Assert
            Assert.IsNull(pageContentService.FindBySectionName(testSectionName));
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
            Assert.Throws<NullReferenceException>(() => pageContentService.FindBySectionName(content.Object.SectionName));
        }
    }
}
