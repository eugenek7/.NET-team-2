using Microsoft.Playwright;

namespace EasyRestPlaywrightSpecFlow.Pages
{
    public class SignInPage
    {
        private IPage _page;

        private ILocator _inputEmail => _page.Locator("//input[@name='email']");
        private ILocator _inputPassword => _page.Locator("//input[@name='password']");
        private ILocator _signInButton => _page.Locator("//span[text()='Sign In']");

        public SignInPage(IPage page) => _page = page;


        public async Task SendKeysToInputEmail(string email)
        {
            await _inputEmail.FillAsync(email);
        }

        public async Task SendKeysToInputPassword(string password)
        {
            await _inputPassword.FillAsync(password);
        }

        public async Task ClickSignInButton()
        {
            await _page.RunAndWaitForNavigationAsync(async () =>
            {
                await _signInButton.ClickAsync();
            }, new PageRunAndWaitForNavigationOptions
            {
                UrlString = "**/moderator"
            });
        }
    }
}

