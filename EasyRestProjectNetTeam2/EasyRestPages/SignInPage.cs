using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class SignInPage : BasePage
    {
        public SignInPage(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement _inputEmail;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement _inputPassword;
        
        [FindsBy(How = How.XPath, Using = "//span[text()='Sign In']")]
        private IWebElement _signInButton;

        [FindsBy(How = How.XPath, Using = "//p[contains(@class, 'MuiTypography-root-41 MuiTypography')]")]
        private IWebElement _warningWindow;
        
        [FindsBy(How = How.XPath, Using = "//a[contains(@href, 'https://accounts.google.com')]")]
        private IWebElement _googleButton;
        
        [FindsBy(How = How.XPath, Using = "//p[contains(@class, 'MuiFormHelperText-root')]")]
        private IWebElement _loginValidationWarningString;

        public void SendKeysEmail(string email)
        {
            _inputEmail.SendKeys(email);
        }

        public void SendKeysPassword(string password)
        {
            _inputPassword.SendKeys(password);
        }
        public void ClickSignInButton()
        {
            
            _signInButton.Click();
        }

        public IWebElement GetWarningWindow()
        {
            return _warningWindow;
        }
        public string GetTextFromWarningWindow()
        {
            return _warningWindow.Text;
        }
        public void ClickGoogleButton()
        {
            _googleButton.Click();
        }
        
        public IWebElement GetValidationWarningString()
        {
            return _loginValidationWarningString;
        }
        public string GetTextFromValidationWarningString()
        {
            return _loginValidationWarningString.Text;
        }
    }
}
