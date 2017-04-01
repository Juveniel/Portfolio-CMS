using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class Create_Should
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
            var contentSectionsController = new ContentSectionsController(
                mockedIPageContentService.Object,
                mockedMappingService.Object,
                mockedImageService.Object);

            //Act & Assert
            contentSectionsController
                .WithCallTo(c => c.Create())
                .ShouldRenderDefaultView();
        }
        
    }
}
