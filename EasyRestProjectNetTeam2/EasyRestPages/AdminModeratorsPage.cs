//http://localhost:8880/admin/moderators(/create)
// Admin
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using EasyRestProjectNetTeam2.EasyRestComponentsObj;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class AdminModeratorsPage : BasePage
    {
        
        public HeaderUsersListComponent HeaderUsersListComponent { get; private set; }

        public AdminModeratorsPage(IWebDriver driver) : base(driver)
        {
            
        }
        [FindsBy(How = How.XPath, Using = "//span[text()='Add moderator']")]
        private IWebElement _createModeratorButton;
        
        [FindsBy(How = How.XPath, Using = "(//span[contains(@class, 'MuiIconButton')])[2]")]
        private IWebElement _banOrActivateModeratorIcon;
        
        [FindsBy(How = How.XPath, Using = "//span[text()='Cancel']")]
        private IWebElement _cancelButton;
        
        [FindsBy(How = How.XPath, Using = "//span[text()='Create account']")]
        private IWebElement _createAccountButton;
        
        [FindsBy(How = How.XPath, Using = "//input[@name='name']")]
        private IWebElement _nameInputField;
        
        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement _emailInputField;
        
        [FindsBy(How = How.XPath, Using = "//input[@name='phoneNumber']")]
        private IWebElement _phoneNumberInputField;
        
        [FindsBy(How = How.XPath, Using = "//input[@name='birthDate']")]
        private IWebElement _birthDateInputField;
        
        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement _passwordInputField;
        
        [FindsBy(How = How.XPath, Using = "//input[@name='repeated_password']")]
        private IWebElement _repeatPasswordInputField;
        
        [FindsBy(How = How.XPath, Using = "//p[contains(text(), 'enter')]")]
        private IWebElement _nameFieldWarning;
        
        [FindsBy(How = How.XPath, Using = "//p[contains(text(), 'valid')]")]
        private IWebElement _emailFieldWarning;
        
        [FindsBy(How = How.XPath, Using = "//p[contains(text(), 'must')]")]
        private IWebElement _passwordFieldWarning;
        
        [FindsBy(How = How.XPath, Using = "//p[contains(text(), 'mismatch')]")]
        private IWebElement _repeatPasswordFieldWarning;
        
        public void ClickBanOrActivateModeratorIcon()
        {
            _banOrActivateModeratorIcon.Click();
        }
        
        public void ClickCreateModeratorButton()
        {
            _createModeratorButton.Click();
        }
        
        public void ClickCancelButton()
        {
            _cancelButton.Click();
        }
        
        public void ClickCreateAccountButton()
        {
            _createAccountButton.Click();
        }

        public void ClickBirthDateInputField()
        {
            _birthDateInputField.Click();
        }
        
        public void SendKeysToNameInputField(string name)
        {
            _nameInputField.SendKeys(name);
        }
        
        public void SendKeysToEmailInputName(string email)
        {
            _emailInputField.SendKeys(email);
        }
        
        public void SendKeysToInputQuantityReorderField(string phone_number)
        {
            _phoneNumberInputField.SendKeys(phone_number);
        }
        
        public void SendKeysToPasswordInputField(string password)
        {
            _passwordInputField.SendKeys(password);
        }
        
        public void SendKeysToRepeatPasswordInputField(string repeat_password)
        {
            _repeatPasswordInputField.SendKeys(repeat_password);
        }
        
        public bool IsInputPasswordValidationWarningExist()
        {
            return _passwordFieldWarning.Displayed;
        }
        
        public bool IsInputNameValidationWarningExist()
        {
            return _nameFieldWarning.Displayed;
        }
        
        public bool IsInputEmailValidationWarningExist()
        {
            return _emailFieldWarning.Displayed;
        }
        
        public bool IsInputRepeatPasswordValidationWarningExist()
        {
            return _repeatPasswordFieldWarning.Displayed;
        }
    }
}
