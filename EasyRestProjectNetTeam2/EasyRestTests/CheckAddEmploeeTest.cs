using EasyRestProjectNetTeam2.EasyRestPages;
using NUnit.Framework;
using System.Threading;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    class CheckAddEmploeeTest : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        ManageRestaurantsPage manageRestaurantsPage;
        MenuPage menuPage;
        ManageAdministratorPage manageAdministratorPage;

        [Test]

        public void CheckAddAdministrator()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SignInWithValidData(dataModel.EmailForOwner, dataModel.PasswordForOwner);
            manageRestaurantsPage = GetManageRestaurantsPage();
            Thread.Sleep(1000);
            //manageRestaurantsPage.WaitForManageAndArchiveButtons(dataModel.TimeToWait);
            manageRestaurantsPage.ClickMoreButton();
            Thread.Sleep(1000);
            manageRestaurantsPage.ClickManage();
            menuPage = GetMenuPage();
            Thread.Sleep(1000);
            menuPage.LeftBarComponent.ClickAdministratorsLeftBarButton();
            Thread.Sleep(1000);
            manageAdministratorPage = GetManageAdministratorPage();
            manageAdministratorPage.ClickPlusAdministrator();
            Thread.Sleep(1000);
            manageAdministratorPage.AddEmploeeComponent.SendKeysToInputName("Lolka");
            manageAdministratorPage.AddEmploeeComponent.SendKeysToInputEmail("lol@lol.gg");
            manageAdministratorPage.AddEmploeeComponent.SendKeysToInputPhoneNumber("123321");
            manageAdministratorPage.AddEmploeeComponent.SendKeysToInputPassword("12345678");
            //manageAdministratorPage.AddEmploeeComponent.ClickAddNewEmploee();
        }
    }
}
