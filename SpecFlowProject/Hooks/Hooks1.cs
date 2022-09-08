using EasyRestSpecFlow.Pages;
using TechTalk.SpecFlow;

namespace EasyRestSpecFlow.Hooks
{
    [Binding]
    public sealed class Hooks1
    {

        [BeforeScenario]
        public void BeforeScenario(HomePage homePage)
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


        