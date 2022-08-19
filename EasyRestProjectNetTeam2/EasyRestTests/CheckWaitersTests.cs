using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Facades;
using EasyRestProjectNetTeam2.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    [TestFixture]
    public class CheckWaitersTests : BaseTest
    {
        HomePage homePage;
        SignUpPage signUpPage;
        FacadeForSignIn facadeForSignIn;
        WaiterPanelPage waiterPanelPage;
        
        [Test]

        public void CheckWaiterIsAbleToConfirmAssignedOrder()
        {
            DatabaseManager.SendNonQuery(queryDataModel.InsertOrderInAssignedWaiterStatus);
            facadeForSignIn = new FacadeForSignIn(driver);
            facadeForSignIn.SignIn(dataModel.WaiterEmail, dataModel.ShortPassword);
            waiterPanelPage = GetWaiterPanelPage();
            waiterPanelPage.WaitClickAssignedWaiterTab(dataModel.TimeToWait);
            waiterPanelPage.WaitClickArrowDownButton(dataModel.TimeToWait);
            waiterPanelPage.WaitClickStartOrderButton(dataModel.TimeToWait);
            waiterPanelPage.WaitConfirmationWindowAndCheckIfDisplayed(dataModel.TimeToWait);
            bool expected = waiterPanelPage.IsConfirmationWindowExist();
            Assert.IsTrue(expected, "Waiter is unable to confirm assigned order");
        }

        [Test]
        public void CheckWaiterIsAbleToCloseOrderFromInProgressTab()
        {
            DatabaseManager.SendNonQuery(queryDataModel.InsertOrderInProgressStatus);
            facadeForSignIn = new FacadeForSignIn(driver);
            facadeForSignIn.SignIn(dataModel.WaiterEmail, dataModel.ShortPassword);
            waiterPanelPage = GetWaiterPanelPage();
            waiterPanelPage.WaitClickInProgressTab(dataModel.TimeToWait);
            waiterPanelPage.WaitClickArrowDownButton(dataModel.TimeToWait);
            waiterPanelPage.WaitClickCloseOrderButton(dataModel.TimeToWait);
            waiterPanelPage.WaitConfirmationWindowAndCheckIfDisplayed(dataModel.TimeToWait);
            bool expected = waiterPanelPage.IsConfirmationWindowExist();
            Assert.IsTrue(expected, "Waiter is unable to close order in progress");
        }

        public override void TearDown()
        {
            DatabaseManager.SendNonQuery(queryDataModel.DeleteTokenByEmail, dataModel.WaiterEmail);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteOrderInAssignedWaiterStatus);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteOrderInProgressStatus);
            base.TearDown();
        }
    }
}