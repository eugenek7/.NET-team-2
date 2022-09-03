using EasyRestPlaywrightSpecflowProject.Drivers;
using PlaywrightTests.Pages;

namespace EasyRestPlaywrightSpecflowProject.StepDefinitions
{
    [Binding]
    public sealed class ModeratorTestsStepDefinitions
    {
        private readonly Driver _driver;
        private readonly LoginPageUpgraded _loginPageUpgraded;
        public const string _url = "http://localhost:3000/";
        public ModeratorTestsStepDefinitions(Driver driver)
        {
            _driver = driver;
            _loginPageUpgraded = new LoginPageUpgraded(_driver.Page);
        }
        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            _driver.Page.GotoAsync(_url);
        }

        [Given(@"I click login link")]
        public async Task GivenIClickLoginLink()
        {
            await _loginPageUpgraded.ClickLoginButton();
        }
    }
}
