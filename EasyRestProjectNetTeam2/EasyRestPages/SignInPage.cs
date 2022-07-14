using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class SignInPage : BasePage
    {
        public HeaderMenuComponent HeaderMenuComponent { get; set; }
        public SignInPage(IWebDriver driver) : base(driver)
        {
            HeaderMenuComponent = new HeaderMenuComponent(driver);
        }

        private const int TimeToWait = 20;

        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement _inputEmail;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement _inputPassword;

        [FindsBy(How = How.XPath, Using = "//p[contains(@class, 'MuiTypography-root-41 MuiTypography')]")]
        private IWebElement _warningWindow;
        
        [FindsBy(How = How.XPath, Using = "//a[contains(@href, 'https://accounts.google.com')]")]
        private IWebElement _googleButton;
        
        [FindsBy(How = How.XPath, Using = "//p[contains(@class, 'MuiFormHelperText-root')]")]
        private IWebElement _loginValidationWarningString;
        
        [FindsBy(How = How.XPath, Using = "//span[text()='Create account']/parent::a")]
        private IWebElement _createAccountButton;

        public void SendKeysToInputEmail(string email)
        {
            _inputEmail.SendKeys(email);
            
        }
        public void WaitForLoginValidationWarningString()
        {
            WaitVisibilityOfElement(TimeToWait, _loginValidationWarningString);
        }

        public void SendKeysToInputPassword(string password)
        {
            _inputPassword.SendKeys(password);
        }

        public void WaitForWarningWindow()
        {
            WaitVisibilityOfElement(TimeToWait, _warningWindow);
        }
        public string GetTextFromWarningWindow()
        {
            return _warningWindow.Text;
        }
        public void ClickGoogleButton()
        {
            _googleButton.Click();
        }
        public string GetTextFromValidationWarningString()
        {
            return _loginValidationWarningString.Text;
        }
        public void ClickCreateAccountButton()
        {
            _createAccountButton.Click();
        }
    }
}
