using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using PortfolioCMS.Business.Common.Constants;
using PortfolioCMS.Business.Models.Content;

namespace PortfolioCMS.Business.Models.Tests.ContentTests
{
    [TestFixture]
    public class PageContentTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            var idProperty = typeof(PageContent).GetProperty("Id");

            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            var model = new PageContent{ Id = testId };

            Assert.AreEqual(testId, model.Id);
        }

        [Test]
        public void SectionName_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(PageContent).GetProperty("SectionName");

            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase("About")]
        [TestCase("Info")]
        public void SectionName_ShouldGetAndSetDataCorrectly(string testName)
        {
            var model = new PageContent { SectionName = testName };

            Assert.AreEqual(testName, model.SectionName);
        }

        [Test]
        public void Title_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(PageContent).GetProperty("Title");

            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Title_ShouldHaveCorrectMinLength()
        {
            var nameProperty = typeof(PageContent).GetProperty("Title");

            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.PageContentNameMinLength));
        }

        [Test]
        public void Title_ShouldHaveCorrectMaxLength()
        {
            var nameProperty = typeof(PageContent).GetProperty("Title");

            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.PageContentNameMaxLength));
        }

        [TestCase("About")]
        [TestCase("Info")]
        public void Title_ShouldGetAndSetDataCorrectly(string testTitle)
        {
            var model = new PageContent { Title = testTitle };

            Assert.AreEqual(testTitle, model.Title);
        }

        [Test]
        public void Content_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(PageContent).GetProperty("Content");

            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Content_ShouldHaveCorrectMinLength()
        {
            var nameProperty = typeof(PageContent).GetProperty("Content");

            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.PageContentDescriptionMinLength));
        }

        [Test]
        public void Content_ShouldHaveCorrectMaxLength()
        {
            var nameProperty = typeof(PageContent).GetProperty("Content");

            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.PageContentDescriptionMaxLength));
        }

        [TestCase("Lorem ipsum dolro sit amet")]
        public void Content_ShouldGetAndSetDataCorrectly(string testContent)
        {
            var model = new PageContent { Content = testContent };

            Assert.AreEqual(testContent, model.Content);
        }
    }
}
