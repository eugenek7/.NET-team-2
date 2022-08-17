using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;

namespace BoaConstrictorTestProject.Interactions.Tasks
{
    public class Insert : ITask
    {
        public string Data { get; }
        public IWebLocator Locator { get; }

        private Insert(string data, IWebLocator locator)
        {
            Data = data;
            Locator = locator;
        }

        public static Insert SuchDataIntoDatafield(string data, IWebLocator locator) => new Insert(data, locator);
        public void PerformAs(IActor actor)
        {
            actor.AttemptsTo(SendKeys.To(Locator, Data));
        }
    }
}
