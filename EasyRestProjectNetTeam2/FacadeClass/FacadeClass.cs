using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;

namespace EasyRestProjectNetTeam2.FacadeClass
{
    public class FacadeClass
    {
        ManageMenuPage manageMenuPage;
        ManageRestaurantsPage manageRestaurantsPage;

        public NavigationFacade(IWebDriver driver)
        {
            manageMenuPage = new ManageMenuPage(driver);
            manageRestaurantsPage = new ManageRestaurantsPage(driver);
        }

        public NavagationFacade NavigationToManageRestaurant(int timeToWait)
        {
            manageRestaurantsPage = GetManageRestaurantsPage();
            manageRestaurantsPage.WaitAndClickMoreButton(timeToWait);
            manageRestaurantsPage.WaitAndClickManageButton(timeToWait);
            manageMenuPage = GetManageMenuPage();



        }



    }
}
