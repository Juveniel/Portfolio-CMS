using System;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Services.Images.Contracts;
using PortfolioCMS.Business.Services.Mappings.Contracts;
using PortfolioCMS.Business.Services.PageContents.Contracts;
using PortfolioCMS.Web.Areas.Admin.Controllers;

namespace PortfolioCMS.Web.Controllers.Tests.Admin.ContentSectionsControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateContentSectionsController_WhenParamsAreValid()
        {
            // Arrange
            var mockedIPageContentService = new Mock<IPageContentService>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedImageService = new Mock<IImageService>();
            var contentSectionsController = new ContentSectionsController(
                mockedIPageContentService.Object,
                mockedMappingService.Object, 
                mockedImageService.Object);

            //Act & Assert
            Assert.That(contentSectionsController, Is.InstanceOf<ContentSectionsController>());
        }

        [Test]
        public void ThrowNullException_WhenPageContentServiceIsNull()
        {
            //Arrange
            Mock<IPageContentService> mockedIPageContentService = null;
            var mockedMappingService = new Mock<IMappingService>();
            var mockedImageService = new Mock<IImageService>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(
                () => new ContentSectionsController(
                    mockedIPageContentService.Object,
                    mockedMappingService.Object,
                    mockedImageService.Object));
        }

        [Test]
        public void ThrowNullException_WhenMappingServiceIsNull()
        {
            //Arrange
            var mockedIPageContentService = new Mock<IPageContentService>(); ;
            Mock<IMappingService> mockedMappingService = null;
            var mockedImageService = new Mock<IImageService>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(
                () => new ContentSectionsController(
                    mockedIPageContentService.Object,
                    mockedMappingService.Object,
                    mockedImageService.Object));
        }

        [Test]
        public void ThrowNullException_WhenImageServiceIsNull()
        {
            //Arrange
            var mockedIPageContentService = new Mock<IPageContentService>(); ;
            var mockedMappingService = new Mock<IMappingService>();
            Mock<IImageService> mockedImageService = null;

            //Act & Assert
            Assert.Throws<NullReferenceException>(
                () => new ContentSectionsController(
                    mockedIPageContentService.Object,
                    mockedMappingService.Object,
                    mockedImageService.Object));
        }
    }
}
