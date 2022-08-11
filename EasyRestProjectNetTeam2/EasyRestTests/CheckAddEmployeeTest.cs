﻿using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Helpers;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    [TestFixture]
    class CheckAddEmployeeTest : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        ManageRestaurantsPage manageRestaurantsPage;
        ManageMenuPage manageMenuPage;
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
            manageMenuPage = GetManageMenuPage();
        }

        [Test, Repeat(10)]
        [Category("(oa) Possibility to manage  administrator")]
        public void CheckAddAdministratorWithValidData()
        {
            manageMenuPage.LeftBarComponent.WaitAndClickAdministratorsLeftBarButton(dataModel.TimeToWait);
            manageAdministratorPage = GetManageAdministratorPage();
            manageAdministratorPage.ClickPlusAdministrator();
            manageAdministratorPage.AddEmployeeComponent.WaitAndSendKeysToInputData(dataModel.NameForNewEmployee,
                dataModel.EmailForNewEmployee, dataModel.PasswordForNewEmployee,
                dataModel.PhoneForNewEmployee, dataModel.TimeToWait);
            manageAdministratorPage.AddEmployeeComponent.ClickAddNewEmployee();
            var actualPageUrl = manageAdministratorPage.WaitAndGetTextFromAdministratorNameField(dataModel.TimeToWait);
            var expectedSearchWord = dataModel.NameForNewEmployee;
            StringAssert.Contains(expectedSearchWord, actualPageUrl, "Search word is absent in employee name field");
        }

        [Test, Repeat(10)]
        [Category("(ow) Possibility to manage waiters")]
        public void CheckAddWaiterWithValidData()
        {
            manageMenuPage.LeftBarComponent.WaitAndClickWaiterLeftBarButton(dataModel.TimeToWait);
            manageWaitersPage = GetManageWaitersPage();
            manageWaitersPage.ClickAddWaiterButton();
            manageWaitersPage.AddEmploeeComponent.WaitAndSendKeysToInputData(dataModel.NameForNewEmployee,
                dataModel.EmailForNewEmployee, dataModel.PasswordForNewEmployee,
                dataModel.PhoneForNewEmployee, dataModel.TimeToWait);
            manageWaitersPage.AddEmploeeComponent.ClickAddNewEmployee();
            var ifUserSuccessFullyAddedPopUpDisplayed = manageWaitersPage.WaitAndCheckIfDisplayedUserSuccesfullyAdded(dataModel.TimeToWait);
            Assert.IsTrue(ifUserSuccessFullyAddedPopUpDisplayed, "Confirmation pop up not displayed");
            var ifNewWaiterAppears = manageWaitersPage.CheckThatNewWaiterAppears(dataModel.NameForNewEmployee);
            Assert.IsTrue(ifNewWaiterAppears, "New Waiter is not added");
        }

        [TearDown]
        public override void TearDown()
        {
            DatabaseManager.SendNonQuery(queryDataModel.SetPreviousAdministrator);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteUserByEmail, dataModel.EmailForNewEmployee);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteTokenByEmail, dataModel.EmailForOwner);
            base.TearDown();
        }
    }
}