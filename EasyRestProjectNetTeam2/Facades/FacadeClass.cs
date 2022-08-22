using EasyRestProjectNetTeam2.EasyRestPages;

namespace EasyRestProjectNetTeam2.FacadeClass
{
    public class NavigateToManageRestaurantFacade
    {
        private readonly ManageMenuPage manageMenuPage;
        private readonly ManageRestaurantsPage manageRestaurantsPage;

        public NavigateToManageRestaurantFacade(ManageMenuPage manageMenuPage, ManageRestaurantsPage manageRestaurantsPage)
        {
            this.manageMenuPage = manageMenuPage;
            this.manageRestaurantsPage = manageRestaurantsPage;
        }

        public void NavigateToManageWaitersPage(int timeToWait)
        {
            manageRestaurantsPage.WaitAndClickMoreButton(timeToWait);
            manageRestaurantsPage.WaitAndClickManageButton(timeToWait);
            manageMenuPage.LeftBarComponent.WaitAndClickWaiterLeftBarButton(timeToWait);
        }

        public void NavigateToManageAdministratorPage(int timeToWait)
        {
            manageRestaurantsPage.WaitAndClickMoreButton(timeToWait);
            manageRestaurantsPage.WaitAndClickManageButton(timeToWait);
            manageMenuPage.LeftBarComponent.WaitAndClickAdministratorsLeftBarButton(timeToWait);
        }
    }
}

