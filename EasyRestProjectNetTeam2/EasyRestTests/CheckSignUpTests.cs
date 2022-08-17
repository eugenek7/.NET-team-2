using EasyRestProjectNetTeam2.EasyRestPages;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    [TestFixture]
    class CheckSignUpTests : BaseTest
    {
        HomePage _homePage;
        SignUpPage _signUpPage;

        [SetUp]
        public override void  SetUp()
        {
            base.SetUp();
            _homePage = GetHomePage();
            _homePage.HeaderMenuComponent.ClickSignUpButton();
            _signUpPage = GetSignUpPage();
        }

        [Test]
        public void CheckUserIsUnableToSignUpWithEmptyFields()
        {
            _signUpPage.ClickCreateAccountButton();
            Assert.Multiple(() =>
            {
                Assert.True(_signUpPage.IsEmptyEmailFieldErrorMessageExist(),
                    "No error message for empty email field");
                Assert.True(_signUpPage.IsEmptyPasswordFieldErrorMessageExist(),
                    "No error message for empty password field");
                Assert.True(_signUpPage.IsEmptyRepeatPasswordFieldErrorMessageExist(), 
                    "No error message for empty repeat password field");
                Assert.True(_signUpPage.IsEmptyNameFieldErrorMessageExist(), 
                    "No error message for empty name field");
            });
        }
        
        [Test]
        public void CheckUserIsUnableToSignUpWithoutName()
        {
            _signUpPage.SendKeysToInputEmail(dataModel.EmailForSignUp);
            _signUpPage.SendKeysToInputPassword(dataModel.PasswordForSignUp);
            _signUpPage.SendKeysToInputConfirmPassword(dataModel.PasswordForSignUp);
            _signUpPage.ClickCreateAccountButton();
            Assert.True(_signUpPage.IsEmptyNameFieldErrorMessageExist(),
                "User is able to sign up without filling out name field");
        }
        
        [Test]
        public void CheckUserIsUnableToSignUpWithoutEmail()
        {
            _signUpPage.SendKeysToInputName(dataModel.NameForSignUp);
            _signUpPage.SendKeysToInputPassword(dataModel.PasswordForSignUp);
            _signUpPage.SendKeysToInputConfirmPassword(dataModel.PasswordForSignUp);
            _signUpPage.ClickCreateAccountButton();
            Assert.True(_signUpPage.IsEmptyEmailFieldErrorMessageExist(),
                "User is able to sign up without filling out email field");
        }
        
        [Test]
        public void CheckUserIsUnableToSignUpWithoutPassword()
        {
            _signUpPage.SendKeysToInputName(dataModel.NameForSignUp);
            _signUpPage.SendKeysToInputEmail(dataModel.EmailForSignUp);
            _signUpPage.ClickCreateAccountButton();
            Assert.True(_signUpPage.IsEmptyPasswordFieldErrorMessageExist(),
                "User is able to sign up without filling out password field");
        }
        
        [Test]
        public void CheckUserIsUnableToSignUpWithShortPassword()
        {
            _signUpPage.SendKeysToInputName(dataModel.NameForSignUp);
            _signUpPage.SendKeysToInputEmail(dataModel.EmailForSignUp);
            _signUpPage.SendKeysToInputPassword(dataModel.ShortPasswordForSignUp);
            _signUpPage.ClickCreateAccountButton();
            Assert.True(_signUpPage.IsInvalidPasswordErrorMessageExist(),
                "User is able to sign up with password of invalid length");
        }
        
        [Test]
        public void CheckUserIsUnableToSignUpWithoutPasswordConfirmation()
        {
            _signUpPage.SendKeysToInputName(dataModel.NameForSignUp);
            _signUpPage.SendKeysToInputEmail(dataModel.EmailForSignUp);
            _signUpPage.SendKeysToInputPassword(dataModel.PasswordForSignUp);
            _signUpPage.ClickCreateAccountButton();
            Assert.True(_signUpPage.IsEmptyRepeatPasswordFieldErrorMessageExist(), 
                "User is able to sign up without password confirmation");
        }
        
        [Test]
        public void CheckUserIsUnableToSignUpWithoutValidPasswordConfirmation()
        {
            _signUpPage.SendKeysToInputName(dataModel.NameForSignUp);
            _signUpPage.SendKeysToInputEmail(dataModel.EmailForSignUp);
            _signUpPage.SendKeysToInputPassword(dataModel.PasswordForSignUp);
            _signUpPage.SendKeysToInputConfirmPassword(dataModel.ShortPasswordForSignUp);
            _signUpPage.ClickCreateAccountButton();
            Assert.True(_signUpPage.IsPasswordMismatchErrorMessageExist(), 
                "User is able to sign up with mismatch passwords");
        }

        [Test]
        public void CheckUserIsUnableToSignUpWithUsedEmail()
        {
            _signUpPage.SendKeysToInputName(dataModel.NameForSignUp);
            _signUpPage.SendKeysToInputEmail(dataModel.AlreadyRegisteredEmail);
            _signUpPage.SendKeysToInputPassword(dataModel.PasswordForSignUp);
            _signUpPage.SendKeysToInputConfirmPassword(dataModel.PasswordForSignUp);
            _signUpPage.ClickCreateAccountButton();
            _signUpPage.WaitForPopUp(dataModel.TimeToWait);
            Assert.True(_signUpPage.IsValidationRegisteredUserErrorMessageExist(),
                "User is able to create another account with already registered email");
        }
    }
}
