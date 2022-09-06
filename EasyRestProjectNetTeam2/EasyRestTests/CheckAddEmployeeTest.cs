using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Facades;
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
        BaseSignIn baseSignIn;

        [SetUp]
        public void SetUp()
        {
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
        public void CheckAddAdministratorWithValidData()
        {
            manageMenuPage.LeftBarComponent.WaitAndClickAdministratorsLeftBarButton(dataModel.TimeToWait);
            manageAdministratorPage = GetManageAdministratorPage();
            manageAdministratorPage.ClickPlusAdministrator();
            manageAdministratorPage.AddEmployeeComponent.WaitAndSendKeysToInputData(dataModel.NameForNewEmployee,
                dataModel.EmailForNewEmployee, dataModel.PasswordForNewEmployee,
                dataModel.PhoneForNewEmployee, dataModel.TimeToWait);
            manageAdministratorPage.AddEmployeeComponent.ClickAddNewEmployee();
            var nameOfActualAdministrator = manageAdministratorPage.WaitAndGetTextFromAdministratorNameField(dataModel.TimeToWait);
            var nameOfExpectedAdministrator = dataModel.NameForNewEmployee;
            StringAssert.Contains(nameOfExpectedAdministrator, nameOfActualAdministrator, "Search word is absent in employee name field");
        }

        [Test]
        [Category("(ow) Possibility to manage waiters")]
        public void CheckAddWaiterWithValidData()
        {
            manageMenuPage.LeftBarComponent.WaitAndClickWaiterLeftBarButton(dataModel.TimeToWait);
            manageWaitersPage = GetManageWaitersPage();
            manageWaitersPage.ClickAddWaiterButton();
            manageWaitersPage.AddEmployeeComponent.WaitAndSendKeysToInputData(dataModel.NameForNewEmployee,
                dataModel.EmailForNewEmployee, dataModel.PasswordForNewEmployee,
                dataModel.PhoneForNewEmployee, dataModel.TimeToWait);
            manageWaitersPage.AddEmployeeComponent.ClickAddNewEmployee();
            var ifUserSuccessfullyAddedPopUpDisplayed = manageWaitersPage.WaitAndCheckIfDisplayedUserSuccesfullyAddedConfirmationPopUp(dataModel.TimeToWait);
            Assert.IsTrue(ifUserSuccessfullyAddedPopUpDisplayed, "Confirmation pop up not displayed");
            var ifNewWaiterAppears = manageWaitersPage.CheckThatNewWaiterAppears(dataModel.NameForNewEmployee);
            Assert.IsTrue(ifNewWaiterAppears, "New Waiter is not added");
        }

        [TearDown]
        public void TearDown()
        {
            DatabaseManager.SendNonQuery(queryDataModel.SetPreviousAdministrator);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteUserByEmail, dataModel.EmailForNewEmployee);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteTokenByEmail, dataModel.EmailForOwner);
        }
    }
}