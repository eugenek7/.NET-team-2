using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace EasyRestProjectSpecflow.PageObjects
{
    public class AdminPage
    {
        private readonly IBrowserInteractions _browserInteractions;

        public AdminPage(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        private IWebElement _banOrActivateButton => _browserInteractions.WaitAndReturnElement
            (By.XPath("(//span[contains(@class, 'MuiIconButton')]/parent::button)[2]"));

        private IWebElement _ActiveUsersButton => _browserInteractions.WaitAndReturnElement
            (By.XPath("//span[contains(text(), 'Active')]"));

        private IWebElement _BannedUsersButton => _browserInteractions.WaitAndReturnElement
            (By.XPath("//span[contains(text(), 'Banned')]"));

        private IList<IWebElement> _listOfUsersNames => (IList<IWebElement>)_browserInteractions.WaitAndReturnElements
            (By.XPath("//th[contains(@class, 'body')]"));

        public void ClickBanOrActivateButton()
        {
            _banOrActivateButton.Click();
        }

        public void ClickActiveUsersButton()
        {
            _ActiveUsersButton.Click();
        }

        public void ClickBannedUsersButton()
        {
            _BannedUsersButton.Click();
        }

        public string GetFirstUserName()
        {
            return _listOfUsersNames[0].Text;
        }

        public bool CheckUserNameExist(string userName)
        {
            return _listOfUsersNames.Any(UserNameElement => UserNameElement.Text.Equals(userName));
        }

    }
}
