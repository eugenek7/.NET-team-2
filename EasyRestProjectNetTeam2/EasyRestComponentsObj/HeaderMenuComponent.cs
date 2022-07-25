using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestComponentsObj
{
    public class HeaderMenuComponent : BasePage
    {
        public HeaderMenuComponent(IWebDriver driver) : base(driver)
        {
        
        }

        private const int TimeToWait = 20;

        [FindsBy(How = How.XPath, Using = "//span[text()='Sign In']")]
        private IWebElement _signInButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'MuiIconButton-label')]")]
        private IWebElement _profileIcon;

        [FindsBy(How = How.XPath, Using = "//a[@role='menuitem']")]
        private IWebElement _rolePanelButton;

        [FindsBy(How = How.XPath, Using = "//li[text()='Log Out']")]
        private IWebElement _logOutButton;

        public void ClickProfileIcon()
        {
            try
            {
                _profileIcon.Click();
            }
            catch (StaleElementReferenceException ex)
            {
                _profileIcon.Click();
            }

        }
        public void ClickLogOutButton()
        {
            _logOutButton.Click();
            driver.Navigate().Refresh();
        }
        public void ClickSignInButton()
        {
            _signInButton.Click();
        }

        public void WaitForProfileIconIsClickable()
        {

            WaitElementIsClickable(TimeToWait, _profileIcon);
        }
        public void WaitRolePanelButtonIsClickable()
        {
            WaitElementIsClickable(TimeToWait, _rolePanelButton);
        }

        public void ClickRolePanelButton()
        {
            _rolePanelButton.Click();
        }
    }
}
