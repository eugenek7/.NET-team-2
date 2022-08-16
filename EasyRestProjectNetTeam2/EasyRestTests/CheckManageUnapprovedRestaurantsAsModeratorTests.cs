using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Helpers;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    class CheckManageUnapprovedRestaurantsAsModeratorTests : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        ModeratorManagePage moderatorManagePage;
        string firstRestaurantName;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SignInWithValidData(dataModel.EmailForModerator, dataModel.ShortPasswordForSignIn);
            moderatorManagePage = GetModeratorManagePage();
            moderatorManagePage.WaitAndClickUnapprovedRestaurantsButton(dataModel.TimeToWait);
        }

        [Test]
        public void CheckDisapproveUnapprovedRestaurant()
        {
            firstRestaurantName = moderatorManagePage.GetFirstRestaurantName();
            moderatorManagePage.ClickDisapproveRestaurantButton();
            moderatorManagePage.WaitAndClickArchivedRestaurantsButton(dataModel.TimeToWait);
            bool restaurantExist = moderatorManagePage.CheckRestaurantNameExist(firstRestaurantName);
            Assert.IsTrue(restaurantExist);
        }

        [TearDown]
        public override void TearDown()
        {
            DatabaseManager.SendNonQuery(queryDataModel.SetRestaurantStatusToUnapprovedByName, firstRestaurantName);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteTokenByEmail, dataModel.EmailForModerator);
            base.TearDown();
        }

    }
}
