using EasyRestProjectSpecflow.PageObjects;
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

    }
}
