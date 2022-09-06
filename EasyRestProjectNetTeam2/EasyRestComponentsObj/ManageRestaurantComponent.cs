using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestComponentsObj
{
    public class ManageRestaurantComponent:BasePage
    {

        public ManageRestaurantComponent(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='name']")]
        private IWebElement _inputRestaurantName;

        [FindsBy(How = How.XPath, Using = "//input[@name='address']")]
        private IWebElement _inputRestaurantAdress;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement _createRestaurantButton;

        [FindsBy(How = How.XPath, Using = "//p[text()='Name is required']")]
        private IWebElement _nameError;

        [FindsBy(How = How.XPath, Using = "//p[text()='Address is required']")]
        private IWebElement _adressError;       
        
        public ManageRestaurantComponent SendKeysToInputRestaurantName(string name)
        {
            _inputRestaurantName.SendKeys(name);
            return this;
        }

        public ManageRestaurantComponent SendKeysToInputRestaurantAdress(string adress)
        {
            _inputRestaurantAdress.SendKeys(adress);
            return this;
        }

        public ManageRestaurantComponent ClickCreateRestaurantButton()
        {
            _createRestaurantButton.Click();
            return this;
        }
        public ManageRestaurantComponent WaitForAppearanceCreatingResturantForm(int timeToWait)
        {
            WaitVisibilityOfElement(timeToWait, _inputRestaurantName);
            return this;
        }
    }
}
