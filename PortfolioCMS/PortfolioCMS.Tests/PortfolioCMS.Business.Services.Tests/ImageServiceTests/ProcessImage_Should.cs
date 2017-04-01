using System.Web;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Services.Images;

namespace PortfolioCMS.Business.Services.Tests.ImageServiceTests
{
    [TestFixture]
    public class ProcessImage_Should
    {
        [TestCase(null)]
        public void ReturnFalse_WhenFileIsNotValid(HttpPostedFileBase file)
        {
            //Arrange
            var imageService = new ImageService();

            //Act & Assert
            Assert.IsFalse(imageService.ProcessImage(file));
        }

        [Test]
        public void ReturnTrue_WhenFileIsValid()
        {
            //Arrange      
            var uploadedFile = new Mock<HttpPostedFileBase>();

            uploadedFile
                .Setup(f => f.ContentLength)
                .Returns(10);

            uploadedFile
                .Setup(f => f.FileName)
                .Returns("testfile.png");

            var imageService = new ImageService();

            //Act & Assert  
            Assert.IsTrue(imageService.ProcessImage(uploadedFile.Object));  

        }
    }
}
