using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using static Boa.Constrictor.WebDriver.WebLocator;

namespace BoaConstrictorTestProject.Pages
{
    public static class HomePage
    {
        public const string Url = "http://localhost:3000/";
        public static IWebLocator SignInButton => L(
        "Sign in button from home page",
        By.XPath("//span[text()='Sign In']"));
    }
}
