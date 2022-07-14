using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;


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


        public void ImplicitWait(int timeToWait)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeToWait);
        }

        protected void WaitVisibilityOfElement(int timeToWait, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(driver => element.Displayed);
        }

        protected void WaitElementIsEnable(int timeToWait, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(driver => element.Enabled);
        }

        protected void WaitElementIsClickable(int timeToWait, IWebElement element)
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

    }
}
