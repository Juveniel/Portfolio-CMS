using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using PortfolioCMS.Business.Models.Projects;

namespace PortfolioCMS.Business.Models.Tests.ProjectsTests
{
    [TestFixture]
    public class ImageTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            var idProperty = typeof(Image).GetProperty("Id");

            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            var model = new Image { Id = testId };

            Assert.AreEqual(testId, model.Id);
        }

        [Test]
        public void Title_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(Image).GetProperty("Title");

            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase("Lorem ipsum dolor sit amet")]
        [TestCase("Test title")]
        public void Title_ShouldGetAndSetDataCorrectly(string testTitle)
        {
            var model = new Image { Title = testTitle };

            Assert.AreEqual(testTitle, model.Title);
        }

        [Test]
        public void Path_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(Image).GetProperty("Path");

            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase("/uploads/images/1/test.png")]
        [TestCase("/uploads/images/3/test.png")]
        public void Path_ShouldGetAndSetDataCorrectly(string testPath)
        {
            var model = new Image { Path = testPath };

            Assert.AreEqual(testPath, model.Path);
        }
    }
}
