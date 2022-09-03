using Microsoft.Playwright;

namespace EasyRestPlaywrightSpecFlow.Pages
{
    public class HomePage
    {
        private IPage _page;
        private ILocator _signInButton => _page.Locator("//span[text()='Sign In']");

        public HomePage(IPage page) => _page = page;


        public async Task ClickSignInButton()
        {
            await _page.RunAndWaitForNavigationAsync(async () =>
            {
                await _signInButton.ClickAsync();
            }, new PageRunAndWaitForNavigationOptions
            {
                UrlString = "**/log-in"
            });
            await _signInButton.ClickAsync();
        }
    }
}

