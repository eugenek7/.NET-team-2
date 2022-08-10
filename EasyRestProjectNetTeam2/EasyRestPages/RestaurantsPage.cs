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
               
        [FindsBy(How = How.XPath, Using = " //span[(text()= 'View all')]/ancestor::a")]
        private IWebElement _viewAllTag;

        [FindsBy(How = How.XPath, Using = "//a[@href='/?tag=beer']")]
        private IWebElement _beerTag;

        [FindsBy(How = How.XPath, Using = "//a[@href='/?tag=kebab']  ")]
        private IWebElement _kebabTag;
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurants/2']")]
        private IWebElement _johnsonDetails;

        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurant/2/menu/3']/..")]
        private IWebElement _johnsonMenu;       

        public void ClickRestarauntsList()
        {
          _restaurantsList.Click();
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
        
        public void ClickJohnsonDetails()
        {
            _johnsonDetails.Click();
        }

        public void ClickJohnsonMenu()
        {
            _johnsonMenu.Click();
        }

        public void WaitForRestaruantDetails(int TimeToWait)
        {
            WaitVisibilityOfElement(TimeToWait, _johnsonDetails);
        }

        public void WaitForRestaruantMenu(int TimeToWait)
        {
            WaitVisibilityOfElement(TimeToWait, _johnsonMenu);
        }

        public void WaitForBeerTag(int TimeToWait)
        {
            WaitVisibilityOfElement(TimeToWait, _beerTag);
        }

        public void WaitForKebabTag(int TimeToWait)
        {
            WaitVisibilityOfElement(TimeToWait, _kebabTag);
        }

        public void WaitForResturantListisCkickable(int TimeToWait)
        {
            WaitElementIsClickable(TimeToWait, _restaurantsList);
        }

        public void WaitForJonsonMenuIsClickable(int timeToWait)
        {
            WaitElementIsClickable(timeToWait, _johnsonMenu);
        }
    }
}
