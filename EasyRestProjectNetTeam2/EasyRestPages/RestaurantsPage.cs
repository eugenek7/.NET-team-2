using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    class RestaurantsPage : BasePage
    {
        public RestaurantsPage(IWebDriver driver) : base(driver)
        {

        }
        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurants']")]
        private IWebElement _restaurantsList;

        [FindsBy(How = How.XPath, Using = "//div [contains(@class, 'MuiPrivateTabScrollButton-root-128')]")]
        private IWebElement _backButton;

        [FindsBy(How = How.XPath, Using = "//button [contains(@class, 'MuiPrivateTabScrollButton-root-128')]")]
        private IWebElement _forwardButton;
               
        [FindsBy(How = How.XPath, Using = " //span[(text()= 'View all')]")]
        private IWebElement _viewAllTag;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'beer')]")]
        private IWebElement _beerTag;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'kebab')]")]
        public IWebElement _kebabTag;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'vegetarian')]")]
        public IWebElement _vegetarianTag;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'sushi')]")]
        public IWebElement _sushiTag;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'fast food')]")]
        public IWebElement _fastFoodTag;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'pub')]")]
        public IWebElement _pubTag;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'ukrainian cuisine')]")]
        public IWebElement _ukrainianCuisineTag;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'burgers')]")]
        public IWebElement _burgersTag;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'japanese cuisine')]")]
        public IWebElement _japanesCuisineTag;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'greel')]")]
        public IWebElement _greelTag;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'pizza')]")]
        public IWebElement _pizzaTag;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'turkish cuisine')]")]
        public IWebElement _turkishCuisineTag;

        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurants/2']")]
        public IWebElement _johnsonDetails;

        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurant/2/menu/3']")]
        public IWebElement _johnsonMenu;

        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurants/5']")]
        public IWebElement _ballLoganDetails;

        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurant/5/menu/9']")]
        public IWebElement _ballLoganMenu;

        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurants/8']")]
        public IWebElement _prestonDetails;
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurant/8/menu/15']")]
        public IWebElement _prestonMenu;

        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurants/4']")]
        public IWebElement _hardyDetails;

        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurant/4/menu/7']")]
        public IWebElement _hardyMenu;

        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurants/9']")]
        public IWebElement _chavezDetails;

        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurant/9/menu/17']")]
        public IWebElement _chavezMenu;


        public void ClickRestarauntsList()
        {
          _restaurantsList.Click();
        }
        public void ClickBackButtont()
        {
            _backButton.Click();
        }
        public void ClickForwardButtont()
        {
            _forwardButton.Click();
        }
        public void ClickViewAllTag()
        {
            _viewAllTag.Click();
        }
        public void ClickBeerTag()
        {
            _beerTag.Click();
        }
        public void ClickKebabTag()
        {
            _kebabTag.Click();
        }
        public void ClickVegetarianTag()
        {
            _vegetarianTag.Click();
        }
        public void ClickSushiTag()
        {
            _sushiTag.Click();
        }
        public void ClickFastFoodTag()
        {
            _fastFoodTag.Click();
        }
        public void ClickPubTag()
        {
            _pubTag.Click();                       
        }
        public void ClickUkrainianCuisineTag()
        {
            _ukrainianCuisineTag.Click();
        }
        public void ClickBurgersTag()
        {
            _burgersTag.Click();
        }
        public void ClickJapanesCuisineTag()
        {
            _japanesCuisineTag.Click();
        }
        public void ClickGreelTag()
        {
            _greelTag.Click();
        }
        public void ClickPizzaTag()
        {
            _pizzaTag.Click();
        }
        public void ClickTurkishCuisineTag()
        {
            _turkishCuisineTag.Click();
        }
        public void ClickJohnsonDetails()
        {
            _johnsonDetails.Click();
        }
        public void ClickJohnsonMenu()
        {
            _johnsonMenu.Click();
        }
        public void ClickballLoganDetails()
        {
            _ballLoganDetails.Click();
        }
        public void ClickballLoganMenu()
        {
            _ballLoganMenu.Click();
        }
        public void ClickPrestonDetails()
        {
            _prestonDetails.Click();
        }
        public void ClickPrestonMenu()
        {
            _prestonMenu.Click();
        }
        public void ClickHardyDetails()
        {
            _hardyDetails.Click();
        }
        public void ClickHardyMenu()
        {
            _hardyMenu.Click();
        }
        public void ClickChavezDetails()
        {
            _chavezDetails.Click();
        }
        public void ClickChavezMenu()
        {
            _chavezMenu.Click();
        }
     
    }

}
