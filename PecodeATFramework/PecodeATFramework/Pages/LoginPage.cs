using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PecodeATFramework.Pages
{
    public class LoginPage
    {
        public IWebDriver WebDriver { get; }

        public LoginPage(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public string UserNameErrorMessageText = "No account found with that username.";

        public IWebElement UserNameInputField => WebDriver.FindElement(By.Name("username"));
        public IWebElement PasswordInputField => WebDriver.FindElement(By.Name("password"));
        public IWebElement LoginButton => WebDriver.FindElement(By.XPath("//*[@value='Login']"));
        public IWebElement UserNameErrorMessage => WebDriver.FindElement(By.XPath("//input[@name='username']//following-sibling::span"));

        public void ClickLoginButton() => LoginButton.Click();

        public void Login(string username, string password)
        {
            UserNameInputField.SendKeys(username);
            PasswordInputField.SendKeys(password);
        }

    }
}
