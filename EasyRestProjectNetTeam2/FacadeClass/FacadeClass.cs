using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;

namespace EasyRestProjectNetTeam2.FacadeClass
{
    public class NavigateTo
    {
        private readonly ManageMenuPage manageMenuPage;
        private readonly ManageRestaurantsPage manageRestaurantsPage;

        public NavigateTo(IWebDriver driver)
        {
            manageMenuPage = new ManageMenuPage(driver);
            manageRestaurantsPage = new ManageRestaurantsPage(driver);
            manageMenuPage = new ManageMenuPage(driver);
        }

        public void ManageWaiters(int timeToWait)
        {
            manageRestaurantsPage.WaitAndClickMoreButton(timeToWait);
            manageRestaurantsPage.WaitAndClickManageButton(timeToWait);
            manageMenuPage.LeftBarComponent.WaitAndClickWaiterLeftBarButton(timeToWait);
        }

        public void ManageAdministrator(int timeToWait)
        {
            manageRestaurantsPage.WaitAndClickMoreButton(timeToWait);
            manageRestaurantsPage.WaitAndClickManageButton(timeToWait);
            manageMenuPage.LeftBarComponent.WaitAndClickAdministratorsLeftBarButton(timeToWait);
        }
    }
}

