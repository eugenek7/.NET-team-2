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

        public string GetSumFromOrder()
        {
            var sumOfOrder = _sumOfOrder.Text;

            return sumOfOrder;
        }
    }
}
