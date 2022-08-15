using EasyRestProjectNetTeam2.Decorator;
using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class ManageAdministratorPage : BasePage
    {
        public AddEmployeeComponent AddEmployeeComponent { get; private set; }

        public ManageAdministratorPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//button[@title='Add Administrator']")]
        private IWebElement _plusAdministratorButton;

        [FindsBy(How = How.XPath, Using = "(//button[contains(@class, 'MuiButtonBase-root')])[2]")]
        private IWebElement _deleteAdministratorButton;

        [FindsBy(How = How.XPath, Using = "(//span[contains(@class, 'MuiTypography')])[5]")]
        private IWebElement _nameAdministrator;

        [FindsBy(How = How.XPath, Using = "//h6[text()='Create your worker:']")]
        private IWebElement _createYourWorkerSign;

        public string WaitAndGetTextFromAdministratorNameField(int timeToWait)
        {
            driver.Navigate().Refresh();
            return _nameAdministrator.WaitAndGetText(driver, timeToWait);
        }

        public void WaitAndClickDeleteAdministrator(int timeToWait)
        {
            _deleteAdministratorButton.WaitAndClick(driver, timeToWait);
        }

        public void ClickPlusAdministrator()
        {
            _plusAdministratorButton.Click();
            AddEmployeeComponent = new AddEmployeeComponent(driver);
        }

        public bool IfCreateYourWorkerSignDisplayed(int timeToWait)
        {
            return _createYourWorkerSign.WaitElementAndCheckIfDisplayed(driver, timeToWait);
        }
    }
}
