using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace EasyRestSpecFlow.PageObject
{
    public class HomePage
    {
        private readonly IBrowserInteractions _browserInteractions;

        public HomePage(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        private static string pageUrl => "http://localhost:3000/";

        private IWebElement _signInButton => _browserInteractions.WaitAndReturnElement(By.XPath("//span[text()='Sign In']"));

        private IWebElement _profileIcon => _browserInteractions.WaitAndReturnElement(By.XPath("//span[contains(@class, 'MuiIconButton-label')]"));

        private IWebElement _rolePanelButton => _browserInteractions.WaitAndReturnElement(By.XPath("//a[@role='menuitem']"));

        public void GoToHomePage()
        {
            _browserInteractions.GoToUrl(pageUrl);
        }

        public void ClickSignInButton()
        {
            _signInButton.Click();
        }

        public void ClickProfileIcon()
        {
            _profileIcon.ClickWithRetry();
        }

        public void ClickRolePanelButton()
        {
            _rolePanelButton.Click();
        }

    }
}
