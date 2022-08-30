using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Facades;
using EasyRestProjectNetTeam2.Helpers;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    class CheckManageRestaurantsAsModeratorTests : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        ModeratorManagePage moderatorManagePage;
        BaseSignIn baseSignIn;

        [SetUp]
        public void SetUp()
        {
            base.SetUp();
            signInPage = GetSignInPage();
            homePage = GetHomePage();
            baseSignIn = new BaseSignIn(signInPage, homePage);
            baseSignIn.SignIn(dataModel.EmailForModerator, dataModel.ShortPassword);
            moderatorManagePage = GetModeratorManagePage();
        }

        [Test, Order(1)]
        [Category("(mm) Possibility to manage restaurants as moderator")]
        public void CheckRestoreArchivedRestaurant()
        {
            moderatorManagePage.WaitAndClickArchivedRestaurantsButton(dataModel.TimeToWait);
            string firstRestaurantName = moderatorManagePage.GetFirstRestaurantName();
            moderatorManagePage.ClickRestoreRestaurantButton();
            moderatorManagePage.WaitAndClickApprovedRestaurantsButton(dataModel.TimeToWait);
            bool restaurantExist = moderatorManagePage.CheckRestaurantNameExist(firstRestaurantName);
            Assert.IsTrue(restaurantExist, "The restaurant did not appear in the approved tab");
        }

        [Test, Order(2)]
        [Category("(mm) Possibility to manage restaurants as moderator")]
        public void CheckDeleteApprovedRestaurant()
        {
            moderatorManagePage.WaitAndClickApprovedRestaurantsButton(dataModel.TimeToWait);
            string firstRestaurantName = moderatorManagePage.GetFirstRestaurantName();
            moderatorManagePage.ClickDeleteRestaurantButton();
            moderatorManagePage.WaitAndClickArchivedRestaurantsButton(dataModel.TimeToWait);
            bool restaurantExist = moderatorManagePage.CheckRestaurantNameExist(firstRestaurantName);
            Assert.IsTrue(restaurantExist, "The restaurant did not appear in the archived tab");
        }

        [Test]
        [Category("(mm) Possibility to manage restaurants as moderator")]
        public void CheckUndoDeleteApprovedRestaurant()
        {
            moderatorManagePage.WaitAndClickApprovedRestaurantsButton(dataModel.TimeToWait);
            string firstRestaurantNameBeforeDelete = moderatorManagePage.GetFirstRestaurantName();
            moderatorManagePage.ClickDeleteRestaurantButton();
            moderatorManagePage.WaitAndClickUndoActionPopUpButton(dataModel.TimeToWait);
            moderatorManagePage.WaitAndClickApprovedRestaurantsButton(dataModel.TimeToWait);
            string firstRestaurantNameAfterDeleteAndUndo = moderatorManagePage.GetFirstRestaurantName();
            Assert.AreEqual(firstRestaurantNameBeforeDelete, firstRestaurantNameAfterDeleteAndUndo,
                "The restaurant did not appear in the approved tab");
        }

        [TearDown]
        public void TearDown()
        {
            DatabaseManager.SendNonQuery(queryDataModel.DeleteTokenByEmail, dataModel.EmailForModerator);
        }

    }
}
