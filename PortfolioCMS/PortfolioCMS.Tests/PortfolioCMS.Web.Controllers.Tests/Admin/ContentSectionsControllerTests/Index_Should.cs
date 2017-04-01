using AutoMapper;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Models.Content;
using PortfolioCMS.Business.Services.Images.Contracts;
using PortfolioCMS.Business.Services.Mappings.Contracts;
using PortfolioCMS.Business.Services.PageContents.Contracts;
using PortfolioCMS.Web.Areas.Admin.Controllers;
using PortfolioCMS.Web.Areas.Admin.Models.ContentSections;
using TestStack.FluentMVCTesting;

namespace PortfolioCMS.Web.Controllers.Tests.Admin.ContentSectionsControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [SetUp]
        public void Initialize()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PageContent, ContentSectionListItemViewModel>());
        }

        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var mockedIPageContentService = new Mock<IPageContentService>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedImageService = new Mock<IImageService>();
            var sectionsController = new ContentSectionsController(
                mockedIPageContentService.Object, 
                mockedMappingService.Object,
                mockedImageService.Object);

            //Act & Assert
            sectionsController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [Test]
        public void InvokeServiceMethod()
        {
            // Arrange
            var mockedIPageContentService = new Mock<IPageContentService>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedImageService = new Mock<IImageService>();
            var sectionsController = new ContentSectionsController(
                mockedIPageContentService.Object,
                mockedMappingService.Object,
                mockedImageService.Object);

            //Act
            sectionsController.Index();

            //Assert
            mockedIPageContentService.Verify(x => x.GetAllPageContents(), Times.Once());
        }       
    }
}
