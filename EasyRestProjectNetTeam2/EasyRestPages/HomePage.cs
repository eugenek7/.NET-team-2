using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Sign In']")]
        private IWebElement _signInButton;
        
        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'MuiIconButton-label')]")]
        private IWebElement _profileIcon;
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/profile/personal_info']")]
        private IWebElement _myProfileMenu;

        public void ClickSignInButton()
        {
            _signInButton.Click();
        }

        public IWebElement GetProfileIcon()
        {
            
            return _profileIcon;
        }

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
        public IWebElement GetMyProfileMenu()
        {
            return _myProfileMenu;
        }

        public void ClickMyProfileMenu()
        {
            
            _myProfileMenu.Click();
        }

    }
}
