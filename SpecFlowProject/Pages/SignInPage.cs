using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace EasyRestSpecFlow.Pages
{
    public class SignInPage
    {
        private readonly IBrowserInteractions _browserInteractions;

        public SignInPage(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        private IWebElement _signInButton => _browserInteractions.WaitAndReturnElement(By.XPath("//span[text()='Sign In']"));

        private IWebElement _inputEmail => _browserInteractions.WaitAndReturnElement(By.XPath("//input[@name='email']"));

        private IWebElement _inputPassword => _browserInteractions.WaitAndReturnElement(By.XPath("//input[@name='password']"));

        public void SendKeysToInputEmail(string email)
        {
            _inputEmail.SendKeys(email);
        }

        public void SendKeysToInputPassword(string password)
        {
            _inputPassword.SendKeys(password);
        }

        public void ClickSignInButton()
        {
            _signInButton.Click();
        }

    }
}