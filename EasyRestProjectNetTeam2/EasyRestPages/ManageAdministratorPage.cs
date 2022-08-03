using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class ManageAdministratorsPage : BasePage
    {
        public AddEmploeeComponent AddEmploeeComponent { get; private set; }
        public ManageAdministratorsPage(IWebDriver driver) : base(driver)
        {

        }

        //[FindsBy(How = How.XPath, Using = "//input[@name='name']")]
        //private IWebElement _inputNameForNewAdministrator;

        //[FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        //private IWebElement _inputEmailForNewAdministrator;

        //[FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        //private IWebElement _inputPasswordForNewAdministrator;

        //[FindsBy(How = How.XPath, Using = "//input[@name='phone_number']")]
        //private IWebElement _inputPhoneNumberForNewAdministrator;

        //[FindsBy(How = How.XPath, Using = "//span[text()='Add']/parent::button")]
        //private IWebElement _addAdministratorButton;

        [FindsBy(How = How.XPath, Using = "//button[@title='Add Administrator']")]
        private IWebElement _plusAdministratorButton;

        [FindsBy(How = How.XPath, Using = "(//button[contains(@class, 'MuiButtonBase-root')])[2]")]
        private IWebElement _deleteAdministratorButton;

        //[FindsBy(How = How.XPath, Using = "//p[text()='Name is required']")]
        //private IWebElement _inputNameValidationWarning;

        //[FindsBy(How = How.XPath, Using = "//p[text()='Mail is required']")]
        //private IWebElement _inputEmailValidationWarning;

        //[FindsBy(How = How.XPath, Using = "//p[text()='Password is required']")]
        //private IWebElement _inputPasswordValidationWarning;

        //[FindsBy(How = How.XPath, Using = "//p[text()='Phone number is required']")]
        //private IWebElement _inputPhoneNumberValidationWarning;


        public void ClickDeleteAdministrator()
        {
            _deleteAdministratorButton.Click();
        }

        //public void SendKeysToInputName(string name)
        //{
        //    _inputNameForNewAdministrator.SendKeys(name);
        //}

        //public void SendKeysToInputEmail(string email)
        //{
        //    _inputEmailForNewAdministrator.SendKeys(email);
        //}

        //public void SendKeysToInputPassword(string password)
        //{
        //    _inputPasswordForNewAdministrator.SendKeys(password);
        //}

        //public void SendKeysToInputPhoneNumber(string phonenumber)
        //{
        //    _inputPhoneNumberForNewAdministrator.SendKeys(phonenumber);
        //}

        public void ClickPlusAdministrator()
        {
            _plusAdministratorButton.Click();
            AddEmploeeComponent = new AddEmploeeComponent(driver);
        }

        //public void ClickAddNewAdministrator()
        //{
        //    _addAdministratorButton.Click();
        //}

        //public bool IsInputNameValidationWarningExist()
        //{
        //    return _inputNameValidationWarning.Displayed;
        //}

        //public bool IsInputEmailValidationWarningExist()
        //{
        //    return _inputEmailValidationWarning.Displayed;
        //}

        //public bool IsInputPasswordValidationWarningExist()
        //{
        //    return _inputPasswordValidationWarning.Displayed;
        //}

        //public bool IsInputPhoneNumberValidationWarningExist()
        //{
        //    return _inputPhoneNumberValidationWarning.Displayed;
        //}
    }
}
