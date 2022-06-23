using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;


namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class BasePage
    {
        readonly IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        

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

        public void WaitForPageLoad(int timeToWait)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

    }
}
