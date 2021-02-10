using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PecodeATFramework.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace PecodeATFramework.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        private IWebDriver driver;

        LoginPage loginPage = null;

        [Given(@"I launch to application")]
        public void GivenILaunchToApplication()
        {
            var service = ChromeDriverService.CreateDefaultService("C://Users//taliana//ChromeDriver");
            service.HideCommandPromptWindow = true;
            driver = new ChromeDriver(service);
            driver.Navigate().GoToUrl("https://www.pecodesoftware.com/qa-portal/registerlogin/registerlogin.php");
            loginPage = new LoginPage(driver);
        }

        [Given(@"I enter the following details")]
        public void GivenIEnterTheFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            loginPage.Login((string)data.UserName, (string)data.Password);
        }

        [Given(@"I click login button")]
        public void GivenIClickLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"I should get error message")]
        public void ThenIShouldGetErrorMessage()
        {
            Assert.That(loginPage.UserNameErrorMessage.Text.Equals(loginPage.UserNameErrorMessageText));
            driver.Quit();
        }

    }
}
