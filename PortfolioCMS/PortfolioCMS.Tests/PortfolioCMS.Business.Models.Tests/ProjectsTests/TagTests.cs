using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using PortfolioCMS.Business.Common.Constants;
using PortfolioCMS.Business.Models.Projects;

namespace PortfolioCMS.Business.Models.Tests.ProjectsTests
{
    [TestFixture]
    public class TagTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            var idProperty = typeof(Tag).GetProperty("Id");

            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            var model = new Tag { Id = testId };

            Assert.AreEqual(testId, model.Id);
        }

        [Test]
        public void Title_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(Tag).GetProperty("Title");

            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Title_ShouldHaveCorrectMinLength()
        {
            var nameProperty = typeof(Tag).GetProperty("Title");

            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.TagNameMinLength));
        }

        [Test]
        public void Title_ShouldHaveCorrectMaxLength()
        {
            var nameProperty = typeof(Tag).GetProperty("Title");

            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.TagNameMaxLength));
        }

        [TestCase("Lorem ipsum dolor sit amet")]
        [TestCase("Test title")]
        public void Title_ShouldGetAndSetDataCorrectly(string testTitle)
        {
            var model = new Tag { Title = testTitle };

            Assert.AreEqual(testTitle, model.Title);
        }
    }
}
