//http://localhost:8880/profile/order_history
// Client & Owner
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class OrderHistoryPage : BasePage
    {
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
        
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Submit')]")]
        private IWebElement _submitReorderButton;
        
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Cancel')]")]
        private IWebElement _cancelReorderButton;
       
        [FindsBy(How = How.XPath, Using = "(//button[@aria-label = 'Remove item'])[1]")]
        private IWebElement _removeItemReorderButton;  
       
        [FindsBy(How = How.XPath, Using = "//input[@type= 'number']")]
        private IWebElement _inputQuantityReorderField;
        
        [FindsBy(How = How.XPath, Using = " //label[contains(text(), 'Date picker')]")]
        private IWebElement _dataPickerReorderField;
        
        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Time picker')]")]
        private IWebElement _timePickerReorderField;
        
        
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
        }
        public void ClickSubmitReorderButton()
        {
            _submitReorderButton.Click();
        }
        public void ClickCancelReorderButton()
        {
            _cancelReorderButton.Click();
        }
        
        public void ClickRemoveItemReorderButton()
        {
            _removeItemReorderButton.Click();
        }
        
        public void IncreaseItemReorderQuantity()
        {
            _inputQuantityReorderField.SendKeys(Keys.ArrowUp);
        }
        public void DecreaseItemReorderQuantity()
        {
            _inputQuantityReorderField.SendKeys(Keys.ArrowDown);
        }
        public void SendKeysToInputQuantityReorderField(string quantity)
        {
            _inputQuantityReorderField.SendKeys(quantity);

        }
        public void ClickOnDataPickerReorderField()
        {
            _dataPickerReorderField.Click();
        }
        
        public void ClickOnTimePickerReorderField()
        {
            _timePickerReorderField.Click();
        }
    }
}
