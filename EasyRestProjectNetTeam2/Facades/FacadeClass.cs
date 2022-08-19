using EasyRestProjectNetTeam2.EasyRestPages;

namespace EasyRestProjectNetTeam2.FacadeClass
{
    public class NavigateTo
    {
        private readonly ManageMenuPage manageMenuPage;
        private readonly ManageRestaurantsPage manageRestaurantsPage;

        public NavigateTo(ManageMenuPage manageMenuPage, ManageRestaurantsPage manageRestaurantsPage)
        {
            this.manageMenuPage = manageMenuPage;
            this.manageRestaurantsPage = manageRestaurantsPage;
        }

        public void ManageWaitersPage(int timeToWait)
        {
            manageRestaurantsPage.WaitAndClickMoreButton(timeToWait);
            manageRestaurantsPage.WaitAndClickManageButton(timeToWait);
            manageMenuPage.LeftBarComponent.WaitAndClickWaiterLeftBarButton(timeToWait);
        }

        public void ManageAdministratorPage(int timeToWait)
        {
            manageRestaurantsPage.WaitAndClickMoreButton(timeToWait);
            manageRestaurantsPage.WaitAndClickManageButton(timeToWait);
            manageMenuPage.LeftBarComponent.WaitAndClickAdministratorsLeftBarButton(timeToWait);
        }
    }
}

