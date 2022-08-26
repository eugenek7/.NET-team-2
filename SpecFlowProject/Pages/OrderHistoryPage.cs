using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlow.Actions.Selenium;


namespace SpecFlowProject.Pages
{
    public class OrderHistoryPage
    {

        private readonly IBrowserInteractions _browserInteractions;

        public OrderHistoryPage(IBrowserInteractions browserInteractions) { _browserInteractions = browserInteractions; }

        private IWebElement _orderHistoryButton => _browserInteractions.WaitAndReturnElement(By.XPath("//span[contains(text(), 'Order History')]"));
        private IWebElement _allOrdersButton => _browserInteractions.WaitAndReturnElement(By.XPath("//span[contains(text(), 'All')]"));

        private IWebElement _declinedOrdersButton => _browserInteractions.WaitAndReturnElement(By.XPath("//span[contains(text(), 'Declined')]"));

        private IWebElement _failedOrdersButton => _browserInteractions.WaitAndReturnElement(By.XPath("//span[contains(text(), 'Failed')]"));

        private IWebElement _removedOrdersButton => _browserInteractions.WaitAndReturnElement(By.XPath("//span[contains(text(), 'Removed')]"));

        private IWebElement _historyOrdersButton => _browserInteractions.WaitAndReturnElement(By.XPath("//a[@href='/profile/order_history/History']"));

        private IWebElement _dropDownToReorderButton => _browserInteractions.WaitAndReturnElement(By.XPath("(//div[contains(@class, 'expandIcon')])[1]"));

        private IWebElement _reorderButton => _browserInteractions.WaitAndReturnElement(By.XPath("(//span[contains(text(), 'Reorder')]) [1]"));

        private IWebElement _submitButton => _browserInteractions.WaitAndReturnElement(By.XPath("//span[text()='Submit']/parent::button"));

        private IWebElement _inputItemQuantity => _browserInteractions.WaitAndReturnElement(By.XPath("(//td//input[@type= 'number'])[1]"));

        private IWebElement _removeItemButton => _browserInteractions.WaitAndReturnElement(By.XPath("(//td//button[@aria-label = 'Remove item'])[1]"));

        public string GetItemQuantity()
        {
            return _inputItemQuantity.GetAttribute("value");
        }
        public void ClickRemoveItemButton()
        {
            _removeItemButton.Click();
        }

        public void SendKeysToInputItemQuantity(string quantity)
        {
            _inputItemQuantity.SendKeys(quantity);
        }

        public void IncreaseItemQuantity()
        {
            _inputItemQuantity.SendKeys(Keys.ArrowUp);
        }

        public void ClickSubmitButton() 
        {
            _submitButton.Click();
        }

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

        public void ClickOrderHistoryButton()
        {
            _orderHistoryButton.Click();
        }
    }
}
