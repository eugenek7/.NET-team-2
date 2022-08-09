using EasyRestProjectNetTeam2.Decorator;
using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class ManageAdministratorPage : BasePage
    {
        public AddEmployeeComponent AddEmploeeComponent { get; private set; }

        public ManageAdministratorPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//button[@title='Add Administrator']")]
        private IWebElement _plusAdministratorButton;

        [FindsBy(How = How.XPath, Using = "(//button[contains(@class, 'MuiButtonBase-root')])[2]")]
        private IWebElement _deleteAdministratorButton;

        [FindsBy(How = How.XPath, Using = "(//span[contains(@class, 'MuiTypography-root-41 MuiTypography-body1')])[5]")]
        private IWebElement _nameAdministrator;

        public string WaitAndGetTextFromAdministratorNameField(int TimeToWait)
        {
            driver.Navigate().Refresh();
            return _nameAdministrator.WaitAndGetText(driver, TimeToWait);
        }

        public void ClickDeleteAdministrator()
        {
            _deleteAdministratorButton.Click();
        }

        public void ClickPlusAdministrator()
        {
            _plusAdministratorButton.Click();
            AddEmploeeComponent = new AddEmployeeComponent(driver);
        }
    }
}
