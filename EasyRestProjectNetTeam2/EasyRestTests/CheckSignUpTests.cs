using EasyRestProjectNetTeam2.EasyRestPages;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    [TestFixture]
    class CheckSignUpTests : BaseTest
    {
        HomePage homePage;
        SignUpPage signUpPage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignUpButton();
            signUpPage = GetSignUpPage();
        }

        [Test]
        [Category("(uu) Possibility to Sign up")]
        public void CheckUserIsUnableToSignUpWithEmptyFields()
        {
            signUpPage.ClickCreateAccountButton();
            Assert.Multiple(() =>
            {
                Assert.True(signUpPage.IsEmptyEmailFieldErrorMessageExist(),
                    "No error message for empty email field");
                Assert.True(signUpPage.IsEmptyPasswordFieldErrorMessageExist(),
                    "No error message for empty password field");
                Assert.True(signUpPage.IsEmptyRepeatPasswordFieldErrorMessageExist(),
                    "No error message for empty repeat password field");
                Assert.True(signUpPage.IsEmptyNameFieldErrorMessageExist(),
                    "No error message for empty name field");
            });
        }

        [Test]
        [Category("(uu) Possibility to Sign up")]
        public void CheckUserIsUnableToSignUpWithoutName()
        {
            signUpPage.SendKeysToInputEmail(dataModel.EmailForSignUp);
            signUpPage.SendKeysToInputPassword(dataModel.PasswordForSignUp);
            signUpPage.SendKeysToInputConfirmPassword(dataModel.PasswordForSignUp);
            signUpPage.ClickCreateAccountButton();
            Assert.True(signUpPage.IsEmptyNameFieldErrorMessageExist(),
                "User is able to sign up without filling out name field");
        }

        [Test]
        [Category("(uu) Possibility to Sign up")]
        public void CheckUserIsUnableToSignUpWithoutEmail()
        {
            signUpPage.SendKeysToInputName(dataModel.NameForSignUp);
            signUpPage.SendKeysToInputPassword(dataModel.PasswordForSignUp);
            signUpPage.SendKeysToInputConfirmPassword(dataModel.PasswordForSignUp);
            signUpPage.ClickCreateAccountButton();
            Assert.True(signUpPage.IsEmptyEmailFieldErrorMessageExist(),
                "User is able to sign up without filling out email field");
        }

        [Test]
        [Category("(uu) Possibility to Sign up")]
        public void CheckUserIsUnableToSignUpWithoutPassword()
        {
            signUpPage.SendKeysToInputName(dataModel.NameForSignUp);
            signUpPage.SendKeysToInputEmail(dataModel.EmailForSignUp);
            signUpPage.ClickCreateAccountButton();
            Assert.True(signUpPage.IsEmptyPasswordFieldErrorMessageExist(),
                "User is able to sign up without filling out password field");
        }

        [Test]
        [Category("(uu) Possibility to Sign up")]
        public void CheckUserIsUnableToSignUpWithShortPassword()
        {
            signUpPage.SendKeysToInputName(dataModel.NameForSignUp);
            signUpPage.SendKeysToInputEmail(dataModel.EmailForSignUp);
            signUpPage.SendKeysToInputPassword(dataModel.ShortPassword);
            signUpPage.ClickCreateAccountButton();
            Assert.True(signUpPage.IsInvalidPasswordErrorMessageExist(),
                "User is able to sign up with password of invalid length");
        }

        [Test]
        [Category("(uu) Possibility to Sign up")]
        public void CheckUserIsUnableToSignUpWithoutPasswordConfirmation()
        {
            signUpPage.SendKeysToInputName(dataModel.NameForSignUp);
            signUpPage.SendKeysToInputEmail(dataModel.EmailForSignUp);
            signUpPage.SendKeysToInputPassword(dataModel.PasswordForSignUp);
            signUpPage.ClickCreateAccountButton();
            Assert.True(signUpPage.IsEmptyRepeatPasswordFieldErrorMessageExist(),
                "User is able to sign up without password confirmation");
        }

        [Test]
        [Category("(uu) Possibility to Sign up")]
        public void CheckUserIsUnableToSignUpWithoutValidPasswordConfirmation()
        {
            signUpPage.SendKeysToInputName(dataModel.NameForSignUp);
            signUpPage.SendKeysToInputEmail(dataModel.EmailForSignUp);
            signUpPage.SendKeysToInputPassword(dataModel.PasswordForSignUp);
            signUpPage.SendKeysToInputConfirmPassword(dataModel.ShortPassword);
            signUpPage.ClickCreateAccountButton();
            Assert.True(signUpPage.IsPasswordMismatchErrorMessageExist(),
                "User is able to sign up with mismatch passwords");
        }

        [Test]
        [Category("(uu) Possibility to Sign up")]
        public void CheckUserIsUnableToSignUpWithUsedEmail()
        {
            signUpPage.SendKeysToInputName(dataModel.NameForSignUp);
            signUpPage.SendKeysToInputEmail(dataModel.AlreadyRegisteredEmail);
            signUpPage.SendKeysToInputPassword(dataModel.PasswordForSignUp);
            signUpPage.SendKeysToInputConfirmPassword(dataModel.PasswordForSignUp);
            signUpPage.ClickCreateAccountButton();
            signUpPage.WaitForPopUp(dataModel.TimeToWait);
            Assert.True(signUpPage.IsValidationRegisteredUserErrorMessageExist(),
                "User is able to create another account with already registered email");
        }
    }
}
