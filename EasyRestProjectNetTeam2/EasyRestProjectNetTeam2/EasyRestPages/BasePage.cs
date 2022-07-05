using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;


namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class BasePage
    {
        readonly protected IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Sign In']")]
        private IWebElement _signInButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'MuiIconButton-label')]")]
        private IWebElement _profileIcon;

        [FindsBy(How = How.XPath, Using = "//a[@href='/profile/personal_info']")]
        private IWebElement _myProfileMenu;

        [FindsBy(How = How.XPath, Using = "//li[text()='Log Out']")]
        private IWebElement _logOutButton;



        public void ImplicitWait(int timeToWait)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeToWait);
        }

        public void WaitVisibilityOfElement(int timeToWait, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(driver => element.Displayed);
        }

        public void WaitElementIsEnable(int timeToWait, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(driver => element.Enabled);
        }

        public void WaitElementIsClickable(int timeToWait, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitForPageLoad(int timeToWait)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
        public string GetPageUrl()
        {
            return driver.Url;
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
        public void ClickLogOutButton()
        {
            _logOutButton.Click();
            driver.Navigate().Refresh();
        }
        public void ClickSignInButton()
        {
            _signInButton.Click();
        }

        public IWebElement GetProfileIcon()
        {

            return _profileIcon;
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
