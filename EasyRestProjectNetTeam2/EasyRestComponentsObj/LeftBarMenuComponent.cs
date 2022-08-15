using EasyRestProjectNetTeam2.Decorator;
using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestComponentsObj
{
    public class LeftBarComponent : BasePage
    {
        public LeftBarComponent(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Details']/ancestor::a")]
        private IWebElement _detailsLeftBarButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Menues']/ancestor::a")]
        private IWebElement _menuesLeftBarButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Waiters']/ancestor::a")]
        private IWebElement _waitersLeftBarButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Administrators']/ancestor::a")]
        private IWebElement _administratorsLeftBarButton;


        public void ClickDetailsLeftBarButton()
        {
            _detailsLeftBarButton.Click();
        }

        public void ClickMenuesLeftBarButton()
        {
            _menuesLeftBarButton.Click();
        }

        public void ClickWaitersLeftBarButton()
        {
            _waitersLeftBarButton.Click();
        }

        public void ClickAdministratorsLeftBarButton()
        {
            _administratorsLeftBarButton.Click();
        }

        public void WaitAndClickAdministratorsLeftBarButton(int TimeToWait)
        {
            _administratorsLeftBarButton.WaitAndClick(driver, TimeToWait);
        }

        public void WaitAndClickWaiterLeftBarButton(int TimeToWait)
        {
            _waitersLeftBarButton.WaitAndClick(driver, TimeToWait);
        }
    }
}

