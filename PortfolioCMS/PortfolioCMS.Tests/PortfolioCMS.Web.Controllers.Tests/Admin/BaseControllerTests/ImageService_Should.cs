using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Services.Images.Contracts;
using PortfolioCMS.Business.Services.Mappings.Contracts;
using PortfolioCMS.Web.Areas.Admin.Controllers.Base;

namespace PortfolioCMS.Web.Controllers.Tests.Admin.BaseControllerTests
{
    [TestFixture]
    public class ImageService_Should
    {
        [Test]
        public void ReturnMappingServiceInstance()
        {
            // Arrange
            var mockedImageService = new Mock<IImageService>();
            var mockedMappingService = new Mock<IMappingService>();
            var baseController = new BaseController(mockedMappingService.Object, mockedImageService.Object);

            //Act & Assert
            Assert.IsInstanceOf<IImageService>(baseController.ImageService);
        }
    }
}
