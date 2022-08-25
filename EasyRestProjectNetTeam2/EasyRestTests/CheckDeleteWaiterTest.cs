using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Facades;
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
        BaseSignIn baseSignIn;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            DatabaseManager.SendNonQuery(queryDataModel.InsertInDBWaiterForDeleting);
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
        public override void TearDown()
        {
            DatabaseManager.SendNonQuery(queryDataModel.DeleteTokenByEmail, dataModel.EmailForOwner);
            base.TearDown();
        }
    }
}
