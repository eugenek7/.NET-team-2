using EasyRestPlaywrightSpecFlow.Pages;
using EasyRestPlaywrightSpecflowProject.Drivers;

namespace EasyRestPlaywrightSpecflowProject.StepDefinitions
{
    [Binding]
    public sealed class EasyRestModeratorTestsStepDefinitions
    {
        private readonly Driver _driver;
        private HomePage _homePage;
        private SignInPage _signInPage;
        private ModeratorManagePage _moderatorManagePage;
        public const string _url = "http://localhost:3000/";
        private string firstName;

        public EasyRestModeratorTestsStepDefinitions(Driver driver)
        {
            _driver = driver;
        }

        [Given(@"I go to Easy rest page")]
        public void GivenIGoToEasyRestPage()
        {
            _driver.Page.GotoAsync(_url);
            _homePage = new HomePage(_driver.Page);
        }

        [Given(@"I log in to my account with '([^']*)' and '([^']*)'")]
        public async Task GivenILogInToMyAccountWithAnd(string email, string password)
        {
            await _homePage.ClickSignInButton();
            _signInPage = new SignInPage(_driver.Page);
            await _signInPage.SendKeysToInputEmail(email);
            await _signInPage.SendKeysToInputPassword(password);
            await _signInPage.ClickSignInButton();
        }


        [Given(@"I go to Users tab")]
        public async Task GivenIGoToUsersTab()
        {
            _moderatorManagePage = new ModeratorManagePage(_driver.Page);
            await _moderatorManagePage.ClickUsersButton();
        }

        [Given(@"I go to Active tab")]
        [When(@"I go to Active tab")]
        public async Task GivenIGoToActiveTab()
        {
            await _moderatorManagePage.ClickActiveButton();
        }

        [When(@"I ban first active user")]
        [When(@"I unban first active user")]
        public async Task WhenIBanFirstActiveUser()
        {
            var personsNames = await _moderatorManagePage.GetAllNames();
            firstName = personsNames[0];
            await _moderatorManagePage.BanOrUnbanFirstPerson();
        }

        [Given(@"I go to Banned tab")]
        [When(@"I go to Banned tab")]
        public async Task WhenIGoToBannedTab()
        {
            await _moderatorManagePage.ClickBannedButton();
        }

        [Then(@"I check that same user appears in banned tab")]
        [Then(@"I check that same user appears in active tab")]
        public async Task ThenICheckThatSameUserAppearsInBannedTab()
        {
            var personsNames = await _moderatorManagePage.GetAllNames();
            bool isFirsrtUserExist = await _moderatorManagePage.IsSearchWordPresentInList(personsNames, firstName);
            isFirsrtUserExist.Should().BeTrue();
        }
    }
}
