using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace SpecFlowProject.Pages
{
    public class CurrentOrdersPage
    {

        private readonly IBrowserInteractions _browserInteractions;

        public CurrentOrdersPage(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }
        private IWebElement _currentOrdersButton => _browserInteractions.WaitAndReturnElement
            (By.XPath("//span[contains(text(), 'Current Orders')]"));

        private IWebElement _waitingforconfirm => _browserInteractions.WaitAndReturnElement
            (By.XPath("//span[contains(text(), 'Waiting for confirm')]"));

        private IWebElement _firstOrder => _browserInteractions.WaitAndReturnElement
            (By.XPath("(//div[contains(@class, 'MuiButtonBase-root')]) [1]"));

        public void ClickCurrentOrdersButton()
        {
            _currentOrdersButton.Click();
        }
        public void ClickWaitingforconfirmButton()
        {
            _waitingforconfirm.Click();
        }

        public string GetPrice()
        {
            return _firstOrder.Text;
        }
    }
}