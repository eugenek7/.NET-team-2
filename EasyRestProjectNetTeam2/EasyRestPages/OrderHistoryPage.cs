//http://localhost:8880/profile/order_history
// Client & Owner
using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class OrderHistoryPage : BasePage
    {
        public OrderConfirmationPopUpComponent OrderConfirmationPopUpComponent { get; private set; }

        public OrderHistoryPage(IWebDriver driver) : base(driver)
        {
            
        }
        
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'All')]")]
        private IWebElement _allOrdersButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Declined')]")]
        private IWebElement _declinedOrdersButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Failed')]")]
        private IWebElement _failedOrdersButton;
        
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Removed')]")]
        private IWebElement _removedOrdersButton;
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/profile/order_history/History']")]
        private IWebElement _historyOrdersButton;
        
        [FindsBy(How = How.XPath, Using = "(//div[contains(@class, 'expandIcon')])[1]")]
        private IWebElement _dropDownToReorderButton;  
        
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Reorder')]")]
        private IWebElement _reorderButton;
        
        public void ClickAllOrdersButton()
        {
            _allOrdersButton.Click();
        }

        public void ClickDeclinedOrdersButton()
        {
            _declinedOrdersButton.Click();
        }

        public void ClickFailedOrdersButton()
        {
            _failedOrdersButton.Click();
        }

        public void ClickRemovedOrdersButton()
        {
            _removedOrdersButton.Click();
        }

        public void ClickHistoryOrdersButton()
        {
            _historyOrdersButton.Click();
        }
        
        public void ClickDropDownButton()
        {
            _dropDownToReorderButton.Click();
        }
        
        public void ClickReorderButton()
        {
            _reorderButton.Click();
            OrderConfirmationPopUpComponent = new OrderConfirmationPopUpComponent(driver);
        }

    }
}
