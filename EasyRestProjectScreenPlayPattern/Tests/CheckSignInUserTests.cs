using Boa.Constrictor.Logging;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using BoaConstrictorTestProject.Components;
using BoaConstrictorTestProject.Interactions.Tasks;
using BoaConstrictorTestProject.Pages;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace BoaConstrictorTestProject
{
    public class CheckSignInUserTests
    {
        private IActor user;
        private const string _correctEmail = "stevenhall@test.com";
        private const string _invalidEmail = "stepanbandera@test.com";
        private const string _incompleteEmail = "stepan123@gmail";
        private const string _correctPassword = "1111";
        private const string _invalidPassword = "2222";
        private const string _warningMessageText = "Email or password is invalid";
        private const string _googleSearchWord = "google";
        private const string _emptyField = "";


        [SetUp]
        public void InitializeScreenplay()
        {
            user = new Actor(name: "Stepan", logger: new ConsoleLogger());
            user.Can(BrowseTheWeb.With(new ChromeDriver()));
            user.AttemptsTo(Navigate.ToUrl(HomePage.Url));
            user.AttemptsTo(task: MaximizeWindow.ForBrowser());
        }

        [TearDown]
        public void QuitBrowser()
        {
            user.AttemptsTo(QuitWebDriver.ForBrowser());
        }


        [Test]
        [Category("(uu) Possibility to Sign in")]
        public void CheckUserTrySignInWithEmptyFieldsEmailAndPasswordTest()
        {
            user.AttemptsTo(SignIn.WithEmailAndPassword(_emptyField, _emptyField));
            user.WaitsUntil(Appearance.Of(SignInPage.EmailIsRequiredWarningMessage), IsEqualTo.True());
            user.WaitsUntil(Appearance.Of(SignInPage.PasswordValidationWarningMessage), IsEqualTo.True());
        }

        [Test]
        [Category("(uu) Possibility to Sign in")]
        public void CheckUserTrySignInWithEmailAndWithoutPasswordTest()
        {
            user.AttemptsTo(SignIn.WithEmailAndPassword(_correctEmail, _emptyField));
            user.WaitsUntil(Appearance.Of(SignInPage.PasswordValidationWarningMessage), IsEqualTo.True());
        }

        [Test]
        [Category("(uu) Possibility to Sign in")]
        public void CheckUserTrySignInWithPasswordAndWithoutEmailTest()
        {
            user.AttemptsTo(SignIn.WithEmailAndPassword(_emptyField, _correctPassword));
            user.WaitsUntil(Appearance.Of(SignInPage.EmailIsRequiredWarningMessage), IsEqualTo.True());
        }

        [Test]
        [Category("(uu) Possibility to Sign in")]
        public void CheckUserSignInTest()
        {
            user.AttemptsTo(SignIn.WithEmailAndPassword(_correctEmail, _correctPassword));
            user.AttemptsTo(Enter.HisPersonalAccount());
            user.AskingFor(Text.Of(PersonalInfoPage.EmailField)).Should().Be(_correctEmail);
        }

        [Test]
        [Category("(uu) Possibility to Sign in")]
        public void CheckUserLoginWithInvalidEmailAndValidPasswordTest()
        {
            user.AttemptsTo(SignIn.WithEmailAndPassword(_invalidEmail, _correctPassword));
            user.AskingFor(Text.Of(SignInPage.WarningWindow)).Should().Be(_warningMessageText);
        }

        [Test]
        [Category("(uu) Possibility to Sign in")]
        public void CheckUserLoginWithValidEmailAndInvalidPasswordTest()
        {
            user.AttemptsTo(SignIn.WithEmailAndPassword(_correctEmail, _invalidPassword));
            user.AskingFor(Text.Of(SignInPage.WarningWindow)).Should().Be(_warningMessageText);
        }

        [Test]
        [Category("(uu) Possibility to Sign in")]
        public void CheckEmailFieldValidationUserSideTest()
        {
            user.AttemptsTo(SignIn.WithEmailAndPassword(_incompleteEmail, _correctPassword));
            user.WaitsUntil(Appearance.Of(SignInPage.EmailValidationWarningMessage), IsEqualTo.True());
        }

        [Test]
        [Category("(uu) Possibility to Sign in")]
        public void CheckThatLoginWithGoogleButtonSendUserToGooglePageTest()
        {
            user.AttemptsTo(Click.On(HeaderMenu.SignInButton));
            user.AttemptsTo(Click.On(SignInPage.GoogleButton));
            user.AskingFor(CurrentUrl.FromBrowser()).Contains(_googleSearchWord).Should().BeTrue();
        }

        [Test]
        [Category("(uu) Possibility to Sign in")]
        public void CheckThatEnteredDataDoesNotSaveAfterRefreshOfThePageTest()
        {
            user.AttemptsTo(Click.On(HeaderMenu.SignInButton));
            user.AttemptsTo(Insert.SuchDataIntoDatafield(_correctEmail, SignInPage.InputEmail));
            user.AttemptsTo(Insert.SuchDataIntoDatafield(_correctPassword, SignInPage.InputPassword));
            user.AttemptsTo(Refresh.Browser());
            user.AskingFor(ValueAttribute.Of(SignInPage.InputEmail)).Should().BeEmpty();
            user.AskingFor(ValueAttribute.Of(SignInPage.InputPassword)).Should().BeEmpty();
        }
    }
}
