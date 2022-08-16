using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using BoaConstrictorTestProject.Components;
using BoaConstrictorTestProject.Pages;

namespace BoaConstrictorTestProject.Interactions.Tasks
{
    public class SignIn : ITask
    {
        public string Email { get; }
        public string Password { get; }

        private SignIn(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public static SignIn WithEmailAndPassword(string email, string password)
            => new SignIn(email, password);

        public void PerformAs(IActor actor)
        {
            actor.AttemptsTo(Click.On(HeaderMenu.SignInButton));
            actor.AttemptsTo(SendKeys.To(SignInPage.InputEmail, Email));
            actor.AttemptsTo(SendKeys.To(SignInPage.InputPassword, Password));
            actor.AttemptsTo(Click.On(SignInPage.SignInButton));
        }
    }
}
