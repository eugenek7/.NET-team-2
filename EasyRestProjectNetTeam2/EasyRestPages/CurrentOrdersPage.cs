using EasyRestProjectNetTeam2.Decorator;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class CurrentOrdersPage : BasePage
    {
        public CurrentOrdersPage(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "(//div[contains(@class, 'MuiGrid-grid-xs-2')]/p)[1]")]
        private IWebElement _sumOfOrder;

        public string WaitAndGetSumFromLastOrder(int timeToWait)
        {
            return _sumOfOrder.WaitAndGetText(driver, timeToWait);
        }

        public bool WaitAndCheckIfOrderDisplayed(int timeTowait)
        {
            return _sumOfOrder.WaitElementAndCheckIfDisplayed(driver, timeTowait);
        }
    }
}
