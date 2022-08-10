using EasyRestProjectNetTeam2.EasyRestPages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    class CheckManageRestaurantsAsModeratorTests : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        ModeratorManagePage moderatorManagePage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SignInWithValidData(dataModel.EmailForModerator, dataModel.PasswordShort);
            moderatorManagePage = GetModeratorManagePage();
        }

        [Test]
        public void CheckRestoreArchivedRestaurant()
        {
            moderatorManagePage.WaitAndClickArchivedRestaurantsButton(dataModel.TimeToWait);
            moderatorManagePage.ClickRestoreRestaurantButton();
            string actualApprovedRestaurantsButtonText = moderatorManagePage.WaitAndGetTextFromApprovedRestaurantsButton(dataModel.TimeToWait);
            string expectedApprovedRestaurantsButtonText = "APPROVED (4)";
            Assert.AreEqual(expectedApprovedRestaurantsButtonText, actualApprovedRestaurantsButtonText, "Approved restaurants quantity has not changed");
        }

        [Test]
        public void CheckDeleteApprovedRestaurant()
        {
            moderatorManagePage.WaitAndClickApprovedRestaurantsButton(dataModel.TimeToWait);
            moderatorManagePage.ClickDeleteRestaurantButton();
            string actualArchivedRestaurantsButtonText = moderatorManagePage.WaitAndGetTextFromArchivedRestaurantsButton(dataModel.TimeToWait);
            string expectedArchivedRestaurantsButtonText = "ARCHIVED (3)";
            Assert.AreEqual(expectedArchivedRestaurantsButtonText, actualArchivedRestaurantsButtonText, "Archived restaurants quantity has not changed");
        }
    }
}
