using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using PortfolioCMS.Business.Common.Constants;
using PortfolioCMS.Business.Models.Projects;

namespace PortfolioCMS.Business.Models.Tests.UsersTests
{
    [TestFixture]
    public class ApplicationUserTests
    {
        [Test]
        public void FirstName_ShouldHaveCorrectMinLength()
        {
            var firstNameProperty = typeof(ApplicationUser).GetProperty("FirstName");

            var minLengthAttribute = firstNameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMinLength));
        }

        [Test]
        public void FirstName_ShouldHaveCorrectMaxLength()
        {
            var firstNameProperty = typeof(ApplicationUser).GetProperty("FirstName");

            var maxLengthAttribute = firstNameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMaxLength));
        }

        [TestCase("Pesho")]
        [TestCase("Micho")]
        public void FirstName_ShouldGetAndSetDataCorrectly(string testName)
        {
            var userProfile = new ApplicationUser { FirstName = testName };

            Assert.AreEqual(userProfile.FirstName, testName);
        }

        [Test]
        public void LastName_ShouldHaveCorrectMinLength()
        {
            var lastNameProperty = typeof(ApplicationUser).GetProperty("LastName");

            var minLengthAttribute = lastNameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMinLength));
        }

        [Test]
        public void LastName_ShouldHaveCorrectMaxLength()
        {
            var lastNameProperty = typeof(ApplicationUser).GetProperty("LastName");

            var maxLengthAttribute = lastNameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMaxLength));
        }

        [TestCase("Ivanov")]
        [TestCase("Petrov")]
        public void LastName_ShouldGetAndSetDataCorrectly(string testName)
        {
            var userProfile = new ApplicationUser { LastName = testName };

            Assert.AreEqual(userProfile.LastName, testName);
        }

        [TestCase(52)]
        [TestCase(22)]
        public void Age_ShouldGetAndSetDataCorrectly(int testAge)
        {
            var userProfile = new ApplicationUser { Age = testAge };

            Assert.AreEqual(userProfile.Age, testAge);
        }

        [TestCase("/uploads/users/11/avata01.jpg")]
        [TestCase("/uploads/users/11/avata02.jpg")]
        public void AvatarUrl_ShouldGetAndSetDataCorrectly(string testImagePath)
        {
            var userProfile = new ApplicationUser { AvatarUrl = testImagePath };

            Assert.AreEqual(userProfile.AvatarUrl, testImagePath);
        }

        [Test]
        public void Constructor_ShouldInitializeProjectsCollectionCorrectly()
        {
            var user = new ApplicationUser();

            var projects = user.Projects;

            Assert.That(projects, Is.Not.Null.And.InstanceOf<HashSet<Project>>());
        }

        [TestCase(123)]
        [TestCase(12)]
        public void TagsCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            var project = new Project { Id = testId };
            var set = new HashSet<Project> { project };

            var user = new ApplicationUser { Projects = set };

            Assert.AreEqual(user.Projects.Count, 1);
        }
    }
}
