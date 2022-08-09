using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Helpers;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    [TestFixture]
    class CheckAddEmploeeTest : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        ManageRestaurantsPage manageRestaurantsPage;
        MenuPage menuPage;
        ManageAdministratorPage manageAdministratorPage;
        ManageWaitersPage manageWaitersPage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SignInWithValidData(dataModel.EmailForOwner, dataModel.PasswordForOwner);
            manageRestaurantsPage = GetManageRestaurantsPage();
            manageRestaurantsPage.WaitAndClickMoreButton(dataModel.TimeToWait);
            manageRestaurantsPage.WaitAndClickManageButton(dataModel.TimeToWait);
            menuPage = GetMenuPage();
        }

        [Test]
        public void CheckAddAdministrator()
        {
            menuPage.LeftBarComponent.WaitAndClickAdministratorsLeftBarButton(dataModel.TimeToWait);
            manageAdministratorPage = GetManageAdministratorPage();
            manageAdministratorPage.ClickPlusAdministrator();
            manageAdministratorPage.AddEmploeeComponent.WaitAndSendKeysToInputData(dataModel.NameForNewEmploee, dataModel.EmailForNewEmploee, dataModel.PasswordForNewEmploee, dataModel.PhoneForNewEmploee, dataModel.TimeToWait);
            manageAdministratorPage.AddEmploeeComponent.ClickAddNewEmploee();
            var actualPageUrl = manageAdministratorPage.WaitAndGetTextFromAdministratorNameField(dataModel.TimeToWait);
            var expectedSearchWord = dataModel.NameForNewEmploee;
            StringAssert.Contains(expectedSearchWord, actualPageUrl, "Search word is absent in emploee name field");
        }

        [Test]
        public void CheckAddWaiter()
        {
            menuPage.LeftBarComponent.WaitAndClickWaiterLeftBarButton(dataModel.TimeToWait);
            manageWaitersPage = GetManageWaitersPage();
            manageWaitersPage.ClickAddWaiterButton();
            manageWaitersPage.AddEmploeeComponent.WaitAndSendKeysToInputData(dataModel.NameForNewEmploee, dataModel.EmailForNewEmploee, dataModel.PasswordForNewEmploee, dataModel.PhoneForNewEmploee, dataModel.TimeToWait);
            manageWaitersPage.AddEmploeeComponent.ClickAddNewEmploee();
            var actualPageUrl = manageWaitersPage.WaitAndGetTextFromWaitersNameField(dataModel.TimeToWait);
            var expectedSearchWord = dataModel.NameForNewEmploee;
            StringAssert.Contains(expectedSearchWord, actualPageUrl, "Search word is absent in emploee name field");
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
            DatabaseManager.SendNonQuery(queryDataModel.SetPreviousAdministrator);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteUserByEmail, dataModel.EmailForNewEmploee);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteTokenByEmail, dataModel.EmailForOwner);
        }
    }
}