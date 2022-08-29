﻿using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Helpers;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    [TestFixture]
    class CheckDeleteWaiterTest : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        ManageRestaurantsPage manageRestaurantsPage;
        ManageMenuPage manageMenuPage;
        ManageWaitersPage manageWaitersPage;

        [SetUp]
        public void SetUp()
        {
            DatabaseManager.SendNonQuery(queryDataModel.InsertInDBWaiterForDeleting);
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SignInWithValidData(dataModel.EmailForOwner, dataModel.PasswordBase);
            manageRestaurantsPage = GetManageRestaurantsPage();
            manageRestaurantsPage.WaitAndClickMoreButton(dataModel.TimeToWait);
            manageRestaurantsPage.WaitAndClickManageButton(dataModel.TimeToWait);
            manageMenuPage = GetManageMenuPage();
        }

        [Test]
        [Category("(ow) Possibility to manage waiters")]
        public void CheckDeletingWaiter()
        {
            manageMenuPage.LeftBarComponent.WaitAndClickWaiterLeftBarButton(dataModel.TimeToWait);
            manageWaitersPage = GetManageWaitersPage();
            manageWaitersPage.WaitAndClickDeleteButton(dataModel.TimeToWait);
            var ifWaiterInTheList = manageWaitersPage.CheckThatWaiterInTheList(dataModel.NameForNewEmployee, dataModel.TimeToWait);
            Assert.IsFalse(ifWaiterInTheList, "The waiter is still on the list of employees.");
        }

        [TearDown]
        public void TearDown()
        {
            DatabaseManager.SendNonQuery(queryDataModel.DeleteTokenByEmail, dataModel.EmailForOwner);
        }
    }
}
