using EasyRestProjectNetTeam2.Decorator;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class RestaurantsPage : BasePage
    {
        public RestaurantsPage(IWebDriver driver) : base(driver)
        {

        }
        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurants']")]
        private IWebElement _restaurantsList;              
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/?tag=beer']")]
        private IWebElement _beerTag;

        [FindsBy(How = How.XPath, Using = "//a[@href='/?tag=kebab']  ")]
        private IWebElement _kebabTag;
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurants/2']")]
        private IWebElement _johnsonDetails;

        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurant/2/menu/3']/..")]
        private IWebElement _johnsonMenu;                    
                          
        public void WaitAndClickJonsonDetails(int TimeToWait)
        {
            _johnsonDetails.WaitAndClick(driver, TimeToWait);
        }

        public void WaitAndClickJonsonMenu(int TimeToWait)
        {
            _johnsonMenu.WaitAndClick(driver, TimeToWait);
        }                        
        
        public void WaitAndClickResturantList(int TimeToWait)
        {
            _restaurantsList.WaitAndClick(driver, TimeToWait);
        }

        public void WaitAndClicBeerTag(int TimeToWait)
        {
            _beerTag.WaitAndClick(driver, TimeToWait);
        }

        public void WaitAndClicKebabTag(int TimeToWait)
        {
            _kebabTag.WaitAndClick(driver, TimeToWait);
        }       
    }
}