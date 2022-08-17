using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;

namespace BoaConstrictorTestProject.Interactions.Tasks
{
    public class Add : ITask
    {
        public IWebLocator Locator { get; }
        private Add(IWebLocator locator) => Locator = locator;

        public static Add PersonInBanListByClicking(IWebLocator locator) => new Add(locator);
        public static Add PersonInActiveListByClicking(IWebLocator locator) => new Add(locator);

        public void PerformAs(IActor actor)
        {
            actor.AttemptsTo(Click.On(Locator));
        }
    }
}
