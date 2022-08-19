using Boa.Constrictor.Screenplay;

namespace BoaConstrictorTestProject.Interactions.Questions
{
    public class Verify : IQuestion<bool>
    {
        public string SearchWord { get; }
        public IEnumerable<string> ListOfItems { get; set; }

        public Verify(string searchWord, IEnumerable<string> listOfItems)
        {
            SearchWord = searchWord;
            ListOfItems = listOfItems;
        }

        public static Verify isTheSearWordPresentInTheList(string searchWord, IEnumerable<string> listOfItems) =>
            new Verify(searchWord, listOfItems);

        public bool RequestAs(IActor actor)
        {
            return ListOfItems.Any(itemName => itemName.Equals(SearchWord));
        }
    }
}
