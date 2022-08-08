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
            manageAdministratorPage.AddEmploeeComponent.WaitAndSendKeysToInputName("Lozxxzy", dataModel.TimeToWait);
            manageAdministratorPage.AddEmploeeComponent.WaitAndSendKeysToInputEmail("lozzxxkl@lol.gg", dataModel.TimeToWait);
            manageAdministratorPage.AddEmploeeComponent.WaitAndSendKeysToInputPhoneNumber("123321", dataModel.TimeToWait);
            manageAdministratorPage.AddEmploeeComponent.WaitAndSendKeysToInputPassword("12345678", dataModel.TimeToWait);
            manageAdministratorPage.AddEmploeeComponent.ClickAddNewEmploee();
            var actualPageUrl = manageAdministratorPage.WaitAndGetTextFromAdministratorNameField(dataModel.TimeToWait);
            var expectedSearchWord = "Lozxxzy";
            StringAssert.Contains(expectedSearchWord, actualPageUrl, "Search word is name in emploee name field");

            string q1 = "UPDATE restaurants SET administrator_id = '13' where id = 8;";
            DatabaseManager.SendNonQuery(q1);
            string q2 = "delete from users where email = 'lozzxxkl@lol.gg';";
            DatabaseManager.SendNonQuery(q2);
            string q3 = "delete from tokens USING users where tokens.user_id=users.id and users.email='jasonbrown@test.com';";
            DatabaseManager.SendNonQuery(q3);

        }
    }
}