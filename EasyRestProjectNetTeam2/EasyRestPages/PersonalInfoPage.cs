using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    class PersonalInfoPage : BasePage
    {
        public PersonalInfoPage(IWebDriver driver) : base(driver)
        { 

        }
        private const int TimeToWait = 20;

        [FindsBy(How = How.XPath, Using = "//th[contains(text(), 'Name:')]/following-sibling::td")]
        private IWebElement _inputName;

        [FindsBy(How = How.XPath, Using = "//th[contains(text(), 'Birth date:')]/following-sibling::td")]
        private IWebElement _inputBirthDate;
        
        [FindsBy(How = How.XPath, Using = "//th[contains(text(), 'Phone number:')]/following-sibling::td")]
        private IWebElement _inputPhoneNumber;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'Personal Info')]")]
        private IWebElement _personalInfoButton;
        
        public string GetTextFromNameField()
        {
            return _inputName.Text;
        }

        public void WaitInputNameIsVisible()
        {
            WaitVisibilityOfElement(TimeToWait, _inputName);
        }

        public string GetTextFromBirthDateField()
        {
            return _inputBirthDate.Text;
        }

        public void WaitInputBirthDateIsVisible()
        {
            WaitVisibilityOfElement(TimeToWait, _inputBirthDate);
        }
        public string GetTextFromPhoneNumberlField()
        {
            return _inputPhoneNumber.Text;
        }

        public void WaitInputPhoneNumberIsVisible()
        {
            WaitVisibilityOfElement(TimeToWait, _inputPhoneNumber);
        }
               
        public void ClickPersonalInfoButton()
        {
            _personalInfoButton.Click();

        }             
    }
}
