﻿using EasyRestProjectNetTeam2.EasyRestPages;
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
        public void SetUp()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SignInWithValidData(dataModel.EmailForModerator, dataModel.ShortPasswordForSignIn);
            moderatorManagePage = GetModeratorManagePage();
            moderatorManagePage.WaitAndClickUnapprovedRestaurantsButton(dataModel.TimeToWait);
            firstRestaurantName = moderatorManagePage.GetFirstRestaurantName();
        }

        [Test]
        [Category("(mm) Possibility to manage restaurants as moderator")]
        public void CheckDisapproveUnapprovedRestaurant()
        {
            moderatorManagePage.ClickDisapproveRestaurantButton();
            moderatorManagePage.WaitAndClickArchivedRestaurantsButton(dataModel.TimeToWait);
            bool restaurantExist = moderatorManagePage.CheckRestaurantNameExist(firstRestaurantName);
            Assert.IsTrue(restaurantExist, "The restaurant did not appear in the archived tab");
        }

        [Test]
        [Category("(mm) Possibility to manage restaurants as moderator")]
        public void CheckApproveUnapprovedRestaurant()
        {
            moderatorManagePage.ClickApproveRestaurantButton();
            moderatorManagePage.WaitAndClickApprovedRestaurantsButton(dataModel.TimeToWait);
            bool restaurantExist = moderatorManagePage.CheckRestaurantNameExist(firstRestaurantName);
            Assert.IsTrue(restaurantExist, "The restaurant did not appear in the approved tab");
        }

        [TearDown]
        public void TearDown()
        {
            DatabaseManager.SendNonQuery(queryDataModel.SetRestaurantStatusToUnapprovedByName, firstRestaurantName);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteTokenByEmail, dataModel.EmailForModerator);
        }

    }
}
