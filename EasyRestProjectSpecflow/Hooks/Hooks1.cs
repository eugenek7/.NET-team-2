using EasyRestSpecFlow.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
