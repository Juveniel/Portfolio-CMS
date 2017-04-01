using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Models.Content;
using PortfolioCMS.Business.Services.PageContents;

namespace PortfolioCMS.Business.Services.Tests.PageContentServiceTetsts
{
    [TestFixture]
    public class GetAllPageContents_Should
    {
        [Test]
        public void BeCalled_WhenParamsAreValid()
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            pageContentService.GetAllPageContents();

            //Assert
            mockedRepository.Verify(repository => repository.All(), Times.Once);
        }

        [Test]
        public void ReturnIqueryable_WhenInvoked()
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            IEnumerable<PageContent> result = new List<PageContent>() { new PageContent(), new PageContent(), new PageContent() };
            mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

            //Assert
            Assert.IsInstanceOf<IQueryable<PageContent>>(pageContentService.GetAllPageContents());
        }

        [Test]
        public void WorksProperly_WhenInvoked()
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            IEnumerable<PageContent> result = new List<PageContent>() { new PageContent(), new PageContent(), new PageContent() };
            mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

            //Assert
            Assert.AreEqual(pageContentService.GetAllPageContents(), result);
        }

        [Test]
        public void ReturnEmptyCollection_WhenNoDestinations()
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            IEnumerable<PageContent> result = new List<PageContent>();
            mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

            //Assert
            Assert.IsEmpty(pageContentService.GetAllPageContents());
        }

        [Test]
        public void ThrowException_WhenNullDestination()
        {
            //Arrange
            var mockedRepository = new Mock<IEFRepository<PageContent>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var pageContentService = new PageContentService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            IEnumerable<PageContent> result = null;
            mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

            //Assert
            Assert.Throws<ArgumentNullException>(() => pageContentService.GetAllPageContents());
        }
    }
}
