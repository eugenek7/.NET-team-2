using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using static Boa.Constrictor.WebDriver.WebLocator;

namespace BoaConstrictorTestProject.Pages
{
    public static class PersonalInfoPage
    {
        public static IWebLocator EmailField => L(
        "Email field from personal info page",
        By.XPath("//th[contains(text(), 'Email:')]/following-sibling::td"));
    }
}
