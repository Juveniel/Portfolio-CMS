using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PortfolioCMS.Business.Identity;
using PortfolioCMS.Web.Models.Account;
using TestStack.FluentMVCTesting;

namespace PortfolioCMS.Web.Controllers.Tests.Controllers.AccountControllerTests
{
    [TestFixture]
    public class Login_Should
    {
        [Test]
        public void ReturnViewWithReturnUrlInViewBag()
        {
            // Arrange
            var accountController = new AccountController();

            string returnUrl = "url";

            // Act & Assert
            accountController
                .WithCallTo(c => c.Login(returnUrl))
                .ShouldRenderDefaultView();
        }

        [Test]
        public void ReturnViewWithModel_IfModelstateIsInvalid()
        {
            // Arrange    
            var accountController = new AccountController();

            accountController.ModelState.AddModelError("", "dummy error");

            LoginViewModel model = new LoginViewModel();
            string returnUrl = "url";

            // Act & Assert
            accountController
                .WithCallTo(c => c.Login(model, returnUrl))
                .ShouldRenderDefaultView()
                .WithModel(model);
        }

        [Test]
        public void ReturnActionResult_WhenInvoked()
        {
            // Arrange
            var mockedSignInManager = new Mock<ApplicationSignInManager>();
            var accountController = new AccountController();

            LoginViewModel model = new LoginViewModel();
            string returnUrl = "url";

            //Act & Assert
            Assert.IsInstanceOf<Task<ActionResult>>(accountController.Login(model, returnUrl));
        }
    }
}
