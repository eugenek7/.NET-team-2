using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class SignUpPage : BasePage
    {
        public DatePickerComponent DatePickerComponent { get; set; }

        public SignUpPage(IWebDriver driver) : base(driver)
        {

        }
        
        [FindsBy(How = How.XPath, Using = "//input[@name='name']")]
        private IWebElement _inputName;

        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement _inputEmail;

        [FindsBy(How = How.XPath, Using = "//input[@name='phoneNumber']")]
        private IWebElement _inputPhoneNumber;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement _inputPassword;

        [FindsBy(How = How.XPath, Using = "//input[@name='repeated_password']")]
        private IWebElement _inputConfirmPassword;

        [FindsBy(How = How.XPath, Using = "//span[text()='Create account']")]
        private IWebElement _createAccountButton;

        [FindsBy(How = How.XPath, Using = "//input[@name='birthDate']")]
        private IWebElement _inputBirthDate;
        
        [FindsBy(How = How.XPath, Using = "//p[text()='Name is required']")]
        private IWebElement _emptyNameFieldErrorMessage;
        
        [FindsBy(How = How.XPath, Using = "//p[text()='Email is required']")]
        private IWebElement _emptyEmailFieldErrorMessage;
        
        [FindsBy(How = How.XPath, Using = "//p[text()='Password is required']")]
        private IWebElement _emptyPasswordFieldErrorMessage;
        
        [FindsBy(How = How.XPath, Using = "//p[text()='Please repeat password']")]
        private IWebElement _emptyRepeatPasswordFieldErrorMessage;
        
        [FindsBy(How = How.XPath, Using = "//p[text()='Password must have at least 8 characters']")]
        private IWebElement _invalidPasswordErrorMessage;
        
        [FindsBy(How = How.XPath, Using = "//p[text()='Password mismatch']")]
        private IWebElement _passwordMismatchErrorMessage;
        
        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Validation Error')]")]
        private IWebElement _registeredUserEmailValidationError;
        
        public bool IsValidationRegisteredUserErrorMessageExist()
        {
            return _registeredUserEmailValidationError.Displayed;
        }
        
        public bool IsEmptyNameFieldErrorMessageExist()
        {
            return _emptyNameFieldErrorMessage.Displayed;
        }
        
        public bool IsEmptyEmailFieldErrorMessageExist()
        {
            return _emptyEmailFieldErrorMessage.Displayed;
        }
        
        public bool IsEmptyPasswordFieldErrorMessageExist()
        {
            return _emptyPasswordFieldErrorMessage.Displayed;
        }
        
        public bool IsEmptyRepeatPasswordFieldErrorMessageExist()
        {
            return _emptyRepeatPasswordFieldErrorMessage.Displayed;
        }
       
        public bool IsInvalidPasswordErrorMessageExist()
        {
            return _invalidPasswordErrorMessage.Displayed;
        }
        
        public bool IsPasswordMismatchErrorMessageExist()
        {
            return _passwordMismatchErrorMessage.Displayed;
        }
        
        public void WaitForPopUp(int TimeToWait)
        {
            WaitVisibilityOfElement(TimeToWait, _registeredUserEmailValidationError);
        }
        
        public void SendKeysToInputName(string name)
        {
            _inputName.SendKeys(name);
        }
        
        public void ClickToInputBirthDate()
        {
            _inputBirthDate.Click();
            DatePickerComponent = new DatePickerComponent(driver);
        }
        
        public void SendKeysToInputEmail(string email)
        {
            _inputEmail.SendKeys(email);
        }
        
        public void SendKeysToInputPhoneNumber(string phoneNumber)
        {
            _inputPhoneNumber.SendKeys(phoneNumber);
        }
        
        public void SendKeysToInputPassword(string password)
        {
            _inputPassword.SendKeys(password);
        }
        
        public void SendKeysToInputConfirmPassword(string password)
        {
            _inputConfirmPassword.SendKeys(password);
        }
        
        public void ClickCreateAccountButton()
        {
            _createAccountButton.Click();
        }
    }
}
