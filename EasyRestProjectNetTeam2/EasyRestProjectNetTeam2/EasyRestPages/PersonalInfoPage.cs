using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class PersonalInfoPage : BasePage
    {
        public PersonalInfoPage(IWebDriver driver) : base(driver)
        {

        }
        [FindsBy(How = How.XPath, Using = "//th[contains(text(), 'Email:')]/following-sibling::td")]
        private IWebElement _inputEmail;

        public string GetTextFromEmailField()
        {
            return _inputEmail.Text;
        }

        public IWebElement GetInputEmail()
        {
            return _inputEmail;
        }

    }
}
