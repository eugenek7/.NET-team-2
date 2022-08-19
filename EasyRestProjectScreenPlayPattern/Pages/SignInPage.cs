using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using static Boa.Constrictor.WebDriver.WebLocator;

namespace BoaConstrictorTestProject.Pages
{
    public static class SignInPage
    {
        public static IWebLocator InputEmail => L(
        "Input email from sign in page",
        By.XPath("//input[@name='email']"));

        public static IWebLocator InputPassword => L(
        "Input password from sign in page",
        By.XPath("//input[@name='password']"));

        public static IWebLocator SignInButton => L(
        "Sign in button from sign in page",
        By.XPath("//span[text()='Sign In']"));

        public static IWebLocator WarningWindow => L(
        "Warning window from sign in page",
        By.XPath("//p[contains(@class, 'MuiTypography-root-41 MuiTypography')]"));


        public static IWebLocator GoogleButton => L(
        "Google button from sign in page",
        By.XPath("//a[contains(@href, 'https://accounts.google.com')]"));

        public static IWebLocator EmailIsRequiredWarningMessage => L(
        "Email validation warning message from sign in page",
        By.XPath("//p[text() ='Email is required']"));

        public static IWebLocator EmailValidationWarningMessage => L(
        "Email validation warning message from sign in page",
        By.XPath("//p[text() ='Email is not valid']"));

        public static IWebLocator PasswordValidationWarningMessage => L(
        "Password validation warning message from sign in page",
        By.XPath("//p[text() ='Password is required']"));
    }
}
