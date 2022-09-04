using Microsoft.Playwright;

namespace EasyRestPlaywrightSpecFlow.Pages
{
    public class ModeratorManagePage
    {
        private IPage _page;

        private ILocator _usersButton => _page.Locator("//span[text()='Users']");
        private ILocator _ownersButton => _page.Locator("//span[text()='Owners']");
        private ILocator _activeButton => _page.Locator("//span[contains(text(), 'Active')]");
        private ILocator _bannedButton => _page.Locator("//span[contains(text(), 'Banned')]");
        private ILocator _namesFields => _page.Locator("//th[contains(@class, 'MuiTableCell-root') and @scope='row']");
        private ILocator _banOrUnbanButton => _page.Locator("(//span[contains(@class, 'MuiIconButton')])[2]");

        public ModeratorManagePage(IPage page) => _page = page;


        public async Task ClickUsersButton()
        {
            await _page.RunAndWaitForNavigationAsync(async () =>
            {
                await _usersButton.ClickAsync();
            }, new PageRunAndWaitForNavigationOptions
            {
                UrlString = "**/users"
            });
        }

        public async Task ClickOwnersButton()
        {
            await _page.RunAndWaitForNavigationAsync(async () =>
            {
                await _ownersButton.ClickAsync();
            }, new PageRunAndWaitForNavigationOptions
            {
                UrlString = "**/owners"
            });
        }

        public async Task ClickActiveButton()
        {
            await _activeButton.ClickAsync();
        }

        public async Task<IReadOnlyList<string>> GetAllNames()
        {
            var names = await _namesFields.AllTextContentsAsync();
            return names;
        }

        public async Task BanOrUnbanFirstPerson()
        {
            await _banOrUnbanButton.ClickAsync();
        }

        public async Task ClickBannedButton()
        {
            await _bannedButton.ClickAsync();
        }

        public async Task<bool> IsSearchWordPresentInList(IReadOnlyList<string> objectsList, string searchWord) //ASK!!!!!!
        {
            await Task.Delay(0);
            return objectsList.Any(word => word.Equals(searchWord));
        }
    }
}
