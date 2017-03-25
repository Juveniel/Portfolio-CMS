using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using PortfolioCMS.Business.Common.Constants;
using PortfolioCMS.Business.Common.Enumerations;
using PortfolioCMS.Business.Models.Projects;

namespace PortfolioCMS.Business.Models.Tests.ProjectsTests
{
    [TestFixture()]
    public class ProjectTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            var idProperty = typeof(Project).GetProperty("Id");

            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            var model = new Project { Id = testId };

            Assert.AreEqual(testId, model.Id);
        }

        [Test]
        public void Title_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(Project).GetProperty("Title");

            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Title_ShouldHaveCorrectMinLength()
        {
            var nameProperty = typeof(Project).GetProperty("Title");

            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.ProjectNameMinLength));
        }

        [Test]
        public void Title_ShouldHaveCorrectMaxLength()
        {
            var nameProperty = typeof(Project).GetProperty("Title");

            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.ProjectNameMaxLength));
        }

        [TestCase("Lorem ipsum dolor sit amet")]
        [TestCase("Test title")]
        public void Title_ShouldGetAndSetDataCorrectly(string testTitle)
        {
            var model = new Project { Title = testTitle };

            Assert.AreEqual(testTitle, model.Title);
        }

        [Test]
        public void Subtitle_ShouldHaveCorrectMinLength()
        {
            var nameProperty = typeof(Project).GetProperty("Subtitle");

            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.ProjectNameMinLength));
        }

        [Test]
        public void Subtitle_ShouldHaveCorrectMaxLength()
        {
            var nameProperty = typeof(Project).GetProperty("Subtitle");

            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.ProjectNameMaxLength));
        }

        [TestCase("Lorem ipsum dolor sit amet")]
        [TestCase("Test title")]
        public void Subtitle_ShouldGetAndSetDataCorrectly(string testTitle)
        {
            var model = new Project { Subtitle = testTitle };

            Assert.AreEqual(testTitle, model.Subtitle);
        }

        [Test]
        public void Description_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(Project).GetProperty("Description");

            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Description_ShouldHaveCorrectMinLength()
        {
            var nameProperty = typeof(Project).GetProperty("Description");

            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.ProjectDescriptionMinLength));
        }

        [Test]
        public void Description_ShouldHaveCorrectMaxLength()
        {
            var nameProperty = typeof(Project).GetProperty("Description");

            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.ProjectDescriptionMaxLength));
        }

        [TestCase("Lorem ipsum dolor sit amet")]
        [TestCase("Test title")]
        public void Description_ShouldGetAndSetDataCorrectly(string testDescription)
        {
            var model = new Project { Description = testDescription };

            Assert.AreEqual(testDescription, model.Description);
        }

        [Test]
        public void DateStarted_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(Project).GetProperty("DateStarted");

            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase("01/01/2017")]
        public void DateStarted_ShouldGetAndSetDataCorrectly(DateTime testDate)
        {
            var model = new Project { DateStarted = testDate };

            Assert.AreEqual(model.DateStarted, testDate);
        }

        [Test]
        public void DateFinished_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(Project).GetProperty("DateFinished");

            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase("01/01/2017")]
        public void DateFinished_ShouldGetAndSetDataCorrectly(DateTime testDate)
        {
            var model = new Project { DateFinished = testDate };

            Assert.AreEqual(model.DateFinished, testDate);
        }

        [Test]
        public void Category_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(Project).GetProperty("Category");

            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase(ProjectCategory.FrontEnd)]
        [TestCase(ProjectCategory.Backend)]
        public void Category_ShouldGetAndSetDataCorrectly(ProjectCategory testCategory)
        {
            var model = new Project { Category = testCategory };

            Assert.AreEqual(testCategory, model.Category);
        }

        [TestCase("www.test.herokuapp.com")]
        [TestCase("www.test.example.com")]
        public void DemoUrl_ShouldGetAndSetDataCorrectly(string testUrl)
        {
            var model = new Project { DemoUrl = testUrl };

            Assert.AreEqual(testUrl, model.DemoUrl);
        }

        [TestCase("01/01/2017")]
        public void Published_ShouldGetAndSetDataCorrectly(DateTime testDate)
        {
            var model = new Project { Published = testDate };

            Assert.AreEqual(model.Published, testDate);
        }

        [Test]
        public void Constructor_ShouldInitializeCommentsCollectionCorrectly()
        {
            var project = new Project();

            var comments = project.Comments;

            Assert.That(comments, Is.Not.Null.And.InstanceOf<HashSet<Comment>>());
        }

        [TestCase(123)]
        [TestCase(12)]
        public void CommentsCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            var comment = new Comment { Id = testId };
            var set = new HashSet<Comment> { comment };

            var project = new Project { Comments = set };

            Assert.AreEqual(project.Comments.Count, 1);
        }

        [Test]
        public void Constructor_ShouldInitializeImagesCollectionCorrectly()
        {
            var project = new Project();

            var images = project.Images;

            Assert.That(images, Is.Not.Null.And.InstanceOf<HashSet<Image>>());
        }

        [TestCase(123)]
        [TestCase(12)]
        public void ImagesCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            var image = new Image { Id = testId };
            var set = new HashSet<Image> { image };

            var project = new Project { Images = set };

            Assert.AreEqual(project.Images.Count, 1);
        }

        [Test]
        public void Constructor_ShouldInitializeTagsCollectionCorrectly()
        {
            var project = new Project();

            var tags = project.Tags;

            Assert.That(tags, Is.Not.Null.And.InstanceOf<HashSet<Tag>>());
        }

        [TestCase(123)]
        [TestCase(12)]
        public void TagsCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            var tag = new Tag { Id = testId };
            var set = new HashSet<Tag> { tag };

            var project = new Project { Tags = set };

            Assert.AreEqual(project.Tags.Count, 1);
        }
    }
}
