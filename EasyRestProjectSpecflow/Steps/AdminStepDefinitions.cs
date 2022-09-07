using EasyRestProjectSpecflow.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;


namespace EasyRestProjectSpecflow.Steps
{
    [Binding]
    public sealed class AdminStepDefinitions
    {
        private readonly AdminPage _adminPage;
        private string firstUserName;

        public AdminStepDefinitions(AdminPage adminPage)
        {
            _adminPage = adminPage;
        }

        [Given(@"navigate to active users tab")]
        public void GivenNavigateToActiveUsersTab()
        {
            _adminPage.ClickActiveUsersButton();
            firstUserName = _adminPage.GetFirstUserName();  
        }

        [When(@"click the activate button on first user")]
        [When(@"click the ban button on first user")]
        public void WhenClickTheBanButtonOnFirstUser()
        {
            _adminPage.ClickBanOrActivateButton();
        }

        [When(@"navigate to banned users tab")]
        public void WhenNavigateToBannedUsersTab()
        {
            _adminPage.ClickBannedUsersButton();
        }

        [Then(@"first user appears in banned users tab")]
        public void ThenFirstUserAppearsInBannedUsersTab()
        {
            bool userExist = _adminPage.CheckUserNameExist(firstUserName);
            Assert.IsTrue(userExist, "The user did not appear in the banned tab");
        }

        [Given(@"navigate to banned users tab")]
        public void GivenNavigateToBannedUsersTab()
        {
            _adminPage.ClickBannedUsersButton();
            firstUserName = _adminPage.GetFirstUserName();
        }

        [When(@"navigate to active users tab")]
        public void WhenNavigateToActiveUsersTab()
        {
            _adminPage.ClickActiveUsersButton();
        }

        [Then(@"first user appears in active users tab")]
        public void ThenFirstUserAppearsInActiveUsersTab()
        {
            bool userExist = _adminPage.CheckUserNameExist(firstUserName);
            Assert.IsTrue(userExist, "The user did not appear in the active tab");
        }

    }
}
