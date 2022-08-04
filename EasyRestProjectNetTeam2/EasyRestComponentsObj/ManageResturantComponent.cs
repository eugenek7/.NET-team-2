using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestComponentsObj
{
    public class ManageResturantComponent:ManageRestaurantsPage
    {

        public ManageResturantComponent(IWebDriver driver) : base(driver)
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
        
        public ManageResturantComponent SendKeysToInputRestaurantName(string name)
        {
            _inputRestaurantName.SendKeys(name);
            return this;
        }

        public ManageResturantComponent SendKeysToInputRestaurantAdress(string adress)
        {
            _inputRestaurantAdress.SendKeys(adress);
            return this;
        }

        public ManageResturantComponent ClickCreateRestaurantButton()
        {
            _createRestaurantButton.Click();
            return this;
        }
        public ManageResturantComponent WaitForAppearanceCreatingResturantForm(int TimeToWait)
        {
            WaitVisibilityOfElement(TimeToWait, _inputRestaurantName);
            return this;
        }
    }
}
