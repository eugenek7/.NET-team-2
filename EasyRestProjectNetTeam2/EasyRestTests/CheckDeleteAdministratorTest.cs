﻿using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Facades;
using EasyRestProjectNetTeam2.Helpers;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    [TestFixture]
    class CheckDeleteAdministratorTest : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        ManageRestaurantsPage manageRestaurantsPage;
        ManageMenuPage manageMenuPage;
        ManageAdministratorPage manageAdministratorPage;
        BaseSignIn baseSignIn;

        [SetUp]
        public void SetUp()
        {
            DatabaseManager.SendNonQuery(queryDataModel.InsertInDBAdministratorForDeleting);
            DatabaseManager.SendNonQuery(queryDataModel.SetTempAdministrator);
            signInPage = GetSignInPage();
            homePage = GetHomePage();
            baseSignIn = new BaseSignIn(signInPage, homePage);
            baseSignIn.SignIn(dataModel.EmailForOwner, dataModel.PasswordBase);
            manageRestaurantsPage = GetManageRestaurantsPage();
            manageRestaurantsPage.WaitAndClickMoreButton(dataModel.TimeToWait);
            manageRestaurantsPage.WaitAndClickManageButton(dataModel.TimeToWait);
            manageMenuPage = GetManageMenuPage();
        }

        [Test]
        [Category("(oa) Possibility to manage administrator")]
        public void CheckDeletingAdministrator()
        {
            manageMenuPage.LeftBarComponent.WaitAndClickAdministratorsLeftBarButton(dataModel.TimeToWait);
            manageAdministratorPage = GetManageAdministratorPage();
            manageAdministratorPage.WaitAndClickDeleteAdministrator(dataModel.TimeToWait);
            var ifAdministratorListIsEmpty = manageAdministratorPage.IfCreateYourWorkerSignDisplayed(dataModel.TimeToWait);
            Assert.IsTrue(ifAdministratorListIsEmpty, "The administrator is still exist on the list of employees.");
            var findUserInBDbyEmail = DatabaseManager.SendQuery(queryDataModel.SelectUserEmailByEmail, dataModel.EmailForNewEmployee2);
            Assert.IsNull(findUserInBDbyEmail, "User still exist in Database");
        }

        [TearDown]
        public void TearDown()
        {
            DatabaseManager.SendNonQuery(queryDataModel.SetPreviousAdministrator);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteTokenByEmail, dataModel.EmailForOwner);
        }

    }
}
