using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using static Boa.Constrictor.WebDriver.WebLocator;

namespace BoaConstrictorTestProject.Pages
{
    public static class ModeratorManagePage
    {
        public static IWebLocator UsersButton => L(
        "Users button from moderator manage page",
        By.XPath("//span[text()='Users']"));

        public static IWebLocator OwnersButton => L(
        "Owners button from moderator manage page",
        By.XPath("//span[text()='Owners']"));

        public static IWebLocator ActiveButton => L(
        "Active button from moderator manage page",
        By.XPath("//span[contains(text(), 'Active')]"));

        public static IWebLocator NamesFields => L(
        "user names field from moderator manage page",
        By.XPath("//th[contains(@class, 'MuiTableCell-root') and @scope='row']"));

        public static IWebLocator BanOrUnbanButton => L(
        "Ban Or Unban button from moderator manage page",
        By.XPath("(//span[contains(@class, 'MuiIconButton')])[2]"));

        public static IWebLocator BannedButton => L(
        "Banned button from moderator manage page",
        By.XPath("//span[contains(text(), 'Banned')]"));
    }
}
