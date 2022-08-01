using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class SignUpPage : BasePage
    {
        public DatePickerComponent DatePickerComponent { get; private set; }

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
