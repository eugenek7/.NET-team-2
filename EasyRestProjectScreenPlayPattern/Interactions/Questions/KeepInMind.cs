using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;

namespace BoaConstrictorTestProject.Interactions.Questions
{
    public class KeepInMind : IQuestion<string>
    {
        public IWebLocator Locator { get; }

        private KeepInMind(IWebLocator locator) => Locator = locator;

        public static KeepInMind NameOfFirstUserFrom(IWebLocator locator) => new KeepInMind(locator);
        public static KeepInMind NameOfFirstOwnerFrom(IWebLocator locator) => new KeepInMind(locator);

        public string RequestAs(IActor actor)
        {
            string firstStringFromList = actor.AskingFor(Remember.AllInfoFrom(Locator)).First();
            return firstStringFromList;
        }
    }
}
