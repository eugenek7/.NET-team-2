using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using System.Collections.Generic;

namespace BoaConstrictorTestProject.Interactions.Questions
{
    public class Remember : IQuestion<IEnumerable<string>>
    {
        public IWebLocator Locator { get; }

        private Remember(IWebLocator locator) => Locator = locator;

        public static Remember AllInfoFrom(IWebLocator locator) => new Remember(locator);

        public IEnumerable<string> RequestAs(IActor actor)
        {
            var listOfTextsFromElements = actor.AsksFor(TextList.For(Locator));
            return listOfTextsFromElements;
        }
    }
}
