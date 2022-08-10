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

        [Test, Order(1)]
        public void CheckRestoreArchivedRestaurant()
        {
            moderatorManagePage.WaitAndClickArchivedRestaurantsButton(dataModel.TimeToWait);
            string FirstRestaurantName = moderatorManagePage.GetFirstRestaurantName();
            moderatorManagePage.ClickRestoreRestaurantButton();
            moderatorManagePage.WaitAndClickApprovedRestaurantsButton(dataModel.TimeToWait);
            Assert.IsTrue(moderatorManagePage.CheckRestaurantNameExist(FirstRestaurantName));
        }

        [Test, Order(2)]
        public void CheckDeleteApprovedRestaurant()
        {
            moderatorManagePage.WaitAndClickApprovedRestaurantsButton(dataModel.TimeToWait);
            string FirstRestaurantName = moderatorManagePage.GetFirstRestaurantName();
            moderatorManagePage.ClickDeleteRestaurantButton();
            moderatorManagePage.WaitAndClickArchivedRestaurantsButton(dataModel.TimeToWait);
            Assert.IsTrue(moderatorManagePage.CheckRestaurantNameExist(FirstRestaurantName));
        }
    }
}
