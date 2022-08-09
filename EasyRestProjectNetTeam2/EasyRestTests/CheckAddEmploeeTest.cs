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
        }

        [Test]

        public void CheckAddAdministrator()
        {
            menuPage = GetMenuPage();
            menuPage.LeftBarComponent.WaitAndClickAdministratorsLeftBarButton(dataModel.TimeToWait);
            manageAdministratorPage = GetManageAdministratorPage();
            manageAdministratorPage.ClickPlusAdministrator();
            manageAdministratorPage.AddEmploeeComponent.WaitAndSendKeysToInputName(dataModel.NameForNewEmploee, dataModel.TimeToWait);
            manageAdministratorPage.AddEmploeeComponent.SendKeysToInputEmail(dataModel.EmailForNewEmploee);
            manageAdministratorPage.AddEmploeeComponent.SendKeysToInputPhoneNumber(dataModel.PhoneForNewEmploee);
            manageAdministratorPage.AddEmploeeComponent.SendKeysToInputPassword(dataModel.PhoneForNewEmploee);
            manageAdministratorPage.AddEmploeeComponent.ClickAddNewEmploee();
            var actualPageUrl = manageAdministratorPage.WaitAndGetTextFromAdministratorNameField(dataModel.TimeToWait);
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