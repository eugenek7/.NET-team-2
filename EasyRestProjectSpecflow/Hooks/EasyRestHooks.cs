using EasyRestProjectSpecflow.PageObjects;
using TechTalk.SpecFlow;

namespace EasyRestSpecFlow.Hooks
{
    [Binding]
    public sealed class EasyRestHooks
    {

        [BeforeScenario]
        public void NavigateToHomePageBeforeTest(HomePage homePage)
        {
            homePage.GoToHomePage();
        }

        [AfterScenario]
        public void LogOutAfterTest(HomePage homePage)
        {
            homePage.ClickProfileIcon();
            homePage.ClickLogOutButton();
        }

    }
}
