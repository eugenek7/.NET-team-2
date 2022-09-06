using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using static Boa.Constrictor.WebDriver.WebLocator;

namespace BoaConstrictorTestProject.Components
{
    public static class HeaderMenu
    {
        public static IWebLocator SignInButton => L(
        "Sign In button from header menu",
        By.XPath("//span[text()='Sign In']"));

        public static IWebLocator ProfileIcon => L(
        "Profile icon from header menu",
        By.XPath("//span[contains(@class, 'MuiIconButton-label')]"));

        public static IWebLocator RolePanelButton => L(
        "Role panel button from header menu",
        By.XPath("//a[@role='menuitem']"));

        public static IWebLocator LogOutButton => L(
        "Log out button from header menu",
        By.XPath("//li[text()='Log Out']"));
    }
}
