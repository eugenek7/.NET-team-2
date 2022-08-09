using EasyRestProjectNetTeam2.Decorator;
using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class ManageWaitersPage : BasePage
    {

        public AddEmployeeComponent AddEmploeeComponent { get; private set; }

        public ManageWaitersPage(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "(//button[contains(@class, 'MuiButtonBase-root')])[2]")]
        private IWebElement _deleteButton;

        [FindsBy(How = How.XPath, Using = "//button[@title='Add Waiter']")]
        private IWebElement _addWaiterButton;

        [FindsBy(How = How.XPath, Using = " (//span[contains(@class, 'MuiTypography-root-41 MuiTypography-body1')])[7]")] // third one in the list
        private IWebElement _nameWaiter;

        public void ClickDeleteButton()
        {
            _deleteButton.Click();
        }

        public void ClickAddWaiterButton()
        {
            _addWaiterButton.Click();
            AddEmploeeComponent = new AddEmployeeComponent(driver);
        }

        public string WaitAndGetTextFromWaitersNameField(int TimeToWait)
        {
            driver.Navigate().Refresh();
            return _nameWaiter.WaitAndGetText(driver, TimeToWait);
        }
    }
}

