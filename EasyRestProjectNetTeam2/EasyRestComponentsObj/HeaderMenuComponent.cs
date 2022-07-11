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
        
        public HeaderMenuComponent(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Sign In']")]
        private IWebElement _signInButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'MuiIconButton-label')]")]
        private IWebElement _profileIcon;

        [FindsBy(How = How.XPath, Using = "//a[@href='/profile/personal_info']")]
        private IWebElement _myProfileMenu;

        [FindsBy(How = How.XPath, Using = "//li[text()='Log Out']")]
        private IWebElement _logOutButton;

        public HeaderMenuComponent ClickProfileIcon()
        {
            try
            {
                _profileIcon.Click();
                return this;
            }
            catch (StaleElementReferenceException ex)
            {
                _profileIcon.Click();
                return this;
            }

        }
        public HeaderMenuComponent ClickLogOutButton()
        {
            _logOutButton.Click();
            driver.Navigate().Refresh();
            return this;
        }
        public HeaderMenuComponent ClickSignInButton()
        {
            _signInButton.Click();
            return this;
        }

        public IWebElement GetProfileIcon()
        {

            return _profileIcon;
        }
        public IWebElement GetMyProfileMenu()
        {
            return _myProfileMenu;
        }

        public HeaderMenuComponent ClickMyProfileMenu()
        {

            _myProfileMenu.Click();
            return this;
        }
    }
}
