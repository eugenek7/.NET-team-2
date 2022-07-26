using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class ManageWaitersPage : BasePage
    {
        public ManageWaitersPage(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "(//button[contains(@class, 'MuiButtonBase-root')])[2]")]
        private IWebElement _deleteButton;

        [FindsBy(How = How.XPath, Using = "//button[@title='Add Waiter']")]
        private IWebElement _addWaiterButton;

        [FindsBy(How = How.XPath, Using = "//input[@name='name']")]
        private IWebElement _inputName;

        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement _inputEmail;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement _inputPassword;

        [FindsBy(How = How.XPath, Using = "//input[@name='phone_number']")]
        private IWebElement _inputPhoneNumber;

        [FindsBy(How = How.XPath, Using = "//span[text()='Add']/parent::button")]
        private IWebElement _addButton;

        [FindsBy(How = How.XPath, Using = "//p[text()='Name is required']")]
        private IWebElement _inputNameValidationWarning;

        [FindsBy(How = How.XPath, Using = "//p[text()='Mail is required']")]
        private IWebElement _inputEmailValidationWarning;

        [FindsBy(How = How.XPath, Using = "//p[text()='Password is required']")]
        private IWebElement _inputPasswordValidationWarning;

        [FindsBy(How = How.XPath, Using = "//p[text()='Phone number is required']")]
        private IWebElement _inputPhoneNumberValidationWarning;

        public void ClickDeleteButton()
        {
            _deleteButton.Click();
        }

        public void ClickAddWaiterButton()
        {
            _addWaiterButton.Click();
        }
        public void SendKeysToInputName(string name)
        {
            _inputName.SendKeys(name);
        }
        public void SendKeysToInputEmail(string email)
        {
            _inputEmail.SendKeys(email);
        }
        public void SendKeysToInputPassword(string password)
        {
            _inputPassword.SendKeys(password);
        }
        public void SendKeysToInputPhoneNumber(string phoneNumber)
        {
            _inputPhoneNumber.SendKeys(phoneNumber);
        }
        public void ClickAddButton()
        {
            _addButton.Click();
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

