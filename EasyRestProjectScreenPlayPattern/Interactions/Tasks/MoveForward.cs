using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;

namespace BoaConstrictorTestProject.Interactions.Tasks
{
    public class MoveForward : ITask
    {
        public IWebLocator Locator { get; }

        private MoveForward(IWebLocator locator) => Locator = locator;

        public static MoveForward ByClicking(IWebLocator locator) => new MoveForward(locator);

        public void PerformAs(IActor actor)
        {
            actor.AttemptsTo(Click.On(Locator));
        }

    }
}
