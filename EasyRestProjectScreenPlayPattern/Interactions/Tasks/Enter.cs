using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using BoaConstrictorTestProject.Components;

namespace BoaConstrictorTestProject.Interactions.Tasks
{
    public class Enter : ITask
    {
        public static Enter HisPersonalAccount() => new Enter();

        public void PerformAs(IActor actor)
        {
            actor.AttemptsTo(Click.On(HeaderMenu.ProfileIcon));
            actor.AttemptsTo(Click.On(HeaderMenu.ProfileIcon));
            actor.AttemptsTo(Click.On(HeaderMenu.RolePanelButton));
        }

    }
}
