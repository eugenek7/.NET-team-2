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
        private IWebElement _currentOrdersButton => _browserInteractions.WaitAndReturnElement(By.XPath("//span[contains(text(), 'Current Orders')]"));

        private IWebElement _waitingforconfirm => _browserInteractions.WaitAndReturnElement(By.XPath("//span[contains(text(), 'Waiting for confirm')]"));

        private IList<IWebElement> _listOfOrders => (IList<IWebElement>)_browserInteractions.WaitAndReturnElements(By.XPath("//div[contains(@class, 'OrderListPage-root')]"));

        public void ClickCurrentOrdersButton()
        {
            _currentOrdersButton.Click();
        }
        public void ClickWaitingforconfirmButton()
        {
            _waitingforconfirm.Click();
        }

        public bool CheckThatOrserAppears(string orderid)
        {
            return _listOfOrders.Any(orderElement => orderElement.Text.Equals(orderid));
        }
    } 
}

