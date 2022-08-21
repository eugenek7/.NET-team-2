using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Facades;
using EasyRestProjectNetTeam2.Helpers;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    [TestFixture]
    public class CheckWaitersTests : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        BaseSignIn baseSignIn;
        WaiterPanelPage waiterPanelPage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            DatabaseManager.SendNonQuery(queryDataModel.InsertOrderInProgressStatus);
            DatabaseManager.SendNonQuery(queryDataModel.InsertOrderInAssignedWaiterStatus);
            signInPage = GetSignInPage();
            homePage = GetHomePage();
            baseSignIn = new BaseSignIn(signInPage, homePage);
            baseSignIn.SignIn(dataModel.WaiterEmail, dataModel.ShortPassword);
            waiterPanelPage = GetWaiterPanelPage();
        }

        [Test]
        

        public void CheckWaiterIsAbleToConfirmAssignedOrder()
        {
            waiterPanelPage.WaitClickAssignedWaiterTab(dataModel.TimeToWait);
            waiterPanelPage.WaitClickArrowDownButton(dataModel.TimeToWait);
            waiterPanelPage.WaitClickStartOrderButton(dataModel.TimeToWait);
            waiterPanelPage.WaitConfirmationWindowAndCheckIfDisplayed(dataModel.TimeToWait);
            var expected = waiterPanelPage.IsConfirmationWindowExist();
            Assert.IsTrue(expected, "Waiter is unable to confirm assigned order");
        }

        [Test]
        public void CheckWaiterIsAbleToCloseOrderFromInProgressTab()
        {
            waiterPanelPage.WaitClickInProgressTab(dataModel.TimeToWait);
            waiterPanelPage.WaitClickArrowDownButton(dataModel.TimeToWait);
            waiterPanelPage.WaitClickCloseOrderButton(dataModel.TimeToWait);
            waiterPanelPage.WaitConfirmationWindowAndCheckIfDisplayed(dataModel.TimeToWait);
            var expected = waiterPanelPage.IsConfirmationWindowExist();
            Assert.IsTrue(expected, "Waiter is unable to close order in progress");
        }

        [TearDown]
        public override void TearDown()
        {
            DatabaseManager.SendNonQuery(queryDataModel.DeleteTokenByEmail, dataModel.WaiterEmail);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteOrderInAssignedWaiterStatus);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteOrderInProgressStatus);
            base.TearDown();
        }
    }
}