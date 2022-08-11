using EasyRestProjectNetTeam2.Decorator;
using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestComponentsObj
{
    public class AddEmployeeComponent : BasePage
    {
        public AddEmployeeComponent(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='name']")]
        private IWebElement _inputName;

        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement _inputEmail;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement _inputPassword;

        [FindsBy(How = How.XPath, Using = "//input[@name='phone_number']")]
        private IWebElement _inputPhoneNumber;

        [FindsBy(How = How.XPath, Using = "//span[text()='Add']/parent::button")]
        private IWebElement _addEmployeeButton;

        [FindsBy(How = How.XPath, Using = "//p[text()='Name is required']")]
        private IWebElement _inputNameValidationWarning;

        [FindsBy(How = How.XPath, Using = "//p[text()='Mail is required']")]
        private IWebElement _inputEmailValidationWarning;

        [FindsBy(How = How.XPath, Using = "//p[text()='Password is required']")]
        private IWebElement _inputPasswordValidationWarning;

        [FindsBy(How = How.XPath, Using = "//p[text()='Phone number is required']")]
        private IWebElement _inputPhoneNumberValidationWarning;

        public void WaitAndSendKeysToInputName(string name, int timeToWait)
        {
            _inputName.WaitAndSendKeys(driver, timeToWait, name);
        }

        public void WaitAndSendKeysToInputEmail(string email, int timeToWait)
        {
            _inputEmail.WaitAndSendKeys(driver, timeToWait, email);
        }

        public void WaitAndSendKeysToInputPassword(string password, int timeToWait)
        {
            _inputPassword.WaitAndSendKeys(driver, timeToWait, password);
        }

        public void WaitAndSendKeysToInputPhoneNumber(string phonenumber, int timeToWait)
        {
            _inputPhoneNumber.WaitAndSendKeys(driver, timeToWait, phonenumber);
        }

        public void SendKeysToInputEmail(string email)
        {
            _inputEmail.SendKeys(email);
        }

        public void SendKeysToInputPassword(string password)
        {
            _inputPassword.SendKeys(password);
        }

        public void SendKeysToInputPhoneNumber(string phonenumber)
        {
            _inputPhoneNumber.SendKeys(phonenumber);
        }

        public void ClickAddNewEmployee()
        {
            _addEmployeeButton.Click();
        }

        public void WaitAndSendKeysToInputData(string name, string email, string password, string phonenumber, int timeToWait)
        {
            _inputName.WaitAndSendKeys(driver, timeToWait, name);
            _inputEmail.SendKeys(email);
            _inputPassword.SendKeys(password);
            _inputPhoneNumber.SendKeys(phonenumber);
        }

        public bool IsInputNameValidationWarningExist()
        {
            return _inputNameValidationWarning.Displayed;
        }

        public bool IsInputEmailValidationWarningExist()
        {
            return _inputEmailValidationWarning.Displayed;
        }

        public bool IsInputPasswordValidationWarningExist()
        {
            return _inputPasswordValidationWarning.Displayed;
        }

        public bool IsInputPhoneNumberValidationWarningExist()
        {
            return _inputPhoneNumberValidationWarning.Displayed;
        }
    }
}
