using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestComponentsObj
{
    public class HeaderMenuComponent : BasePage
    {
        private IWebDriver driver;
        public HeaderMenuComponent(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private const int TimeToWait = 20;

        [FindsBy(How = How.XPath, Using = "//span[text()='Sign In']")]
        private IWebElement _signInButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'MuiIconButton-label')]")]
        private IWebElement _profileIcon;

        [FindsBy(How = How.XPath, Using = "//a[@href='/profile/personal_info']")]
        private IWebElement _myProfileMenu;

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
        public void WaitMyProfileMenuIsClickable()
        {
            WaitElementIsClickable(TimeToWait, _myProfileMenu);
        }

        public void ClickMyProfileMenu()
        {
            _myProfileMenu.Click();
        }
    }
}
