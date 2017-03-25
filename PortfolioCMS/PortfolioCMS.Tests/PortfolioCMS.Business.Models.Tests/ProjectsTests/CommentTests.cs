using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using PortfolioCMS.Business.Common.Constants;
using PortfolioCMS.Business.Models.Projects;

namespace PortfolioCMS.Business.Models.Tests.ProjectsTests
{
    [TestFixture]
    public class CommentTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            var idProperty = typeof(Comment).GetProperty("Id");

            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            var model = new Comment { Id = testId };

            Assert.AreEqual(testId, model.Id);
        }

        [Test]
        public void Content_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(Comment).GetProperty("Content");

            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Content_ShouldHaveCorrectMinLength()
        {
            var nameProperty = typeof(Comment).GetProperty("Content");

            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.CommentMinLength));
        }

        [Test]
        public void Content_ShouldHaveCorrectMaxLength()
        {
            var nameProperty = typeof(Comment).GetProperty("Content");

            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.CommentMaxLength));
        }

        [TestCase("Lorem ipsum dolor sit amet")]
        [TestCase("Test comment")]
        public void Content_ShouldGetAndSetDataCorrectly(string testContent)
        {
            var model = new Comment { Content = testContent };

            Assert.AreEqual(testContent, model.Content);
        }

        [Test]
        public void Created_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(Comment).GetProperty("Created");

            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase("01/01/2017")]
        public void Created_ShouldGetAndSetDataCorrectly(DateTime testDate)
        {
            var model = new Comment { Created = testDate };

            Assert.AreEqual(model.Created, testDate);
        }

        [TestCase(12)]
        [TestCase(555)]
        public void ProjectId_ShouldGetAndSetDataCorrectly(int testProejctId)
        {
            var model = new Comment { ProjectId = testProejctId };

            Assert.AreEqual(model.ProjectId, testProejctId);
        }

        [TestCase(55)]
        [TestCase(1)]
        public void Project_ShouldGetAndSetDataCorrectly(int testProjectId)
        {
            var project = new Project { Id = testProjectId };
            var comment = new Comment { Project = project };

            Assert.AreEqual(comment.Project.Id, testProjectId);
        }

        [TestCase("John Wick")]
        [TestCase("Sam Sam")]
        public void Author_ShouldGetAndSetDataCorrectly(string testAuthorName)
        {
            var model = new Comment { Author = testAuthorName };

            Assert.AreEqual(model.Author, testAuthorName);
        }
    }
}
