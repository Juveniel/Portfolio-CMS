using System.IO;
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
            string solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
            string filePath = Path.Combine(solutionDir, @"ImageServiceTests\TestFiles\testfile.png");
            var fileStream = new FileStream(filePath, FileMode.Open);
            var uploadedFile = new Mock<HttpPostedFileBase>();

            uploadedFile
                .Setup(f => f.ContentLength)
                .Returns(10);

            uploadedFile
                .Setup(f => f.FileName)
                .Returns("testfile.png");

            uploadedFile
                .Setup(f => f.InputStream)
                .Returns(fileStream);

            var imageService = new ImageService();

            //Act & Assert
            Assert.IsTrue(imageService.ProcessImage(uploadedFile.Object));
            fileStream.Close();
        }
    }
}
