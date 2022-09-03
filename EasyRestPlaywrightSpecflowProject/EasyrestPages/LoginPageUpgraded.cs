using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class LoginPageUpgraded
    {
        private IPage _page;
        private ILocator _lnkLogin => _page.Locator("text=Login");
        private ILocator _txtUserName => _page.Locator("//input[@name='UserName']");
        private ILocator _txtPassword => _page.Locator("//input[@name='Password']");
        private ILocator _btnLogin => _page.Locator("text=Log in");
        private ILocator _lnkEmployeeDetails => _page.Locator("text=Employee Details");
        private ILocator _lnkEmployeeLists => _page.Locator("text=Employee List");
        public LoginPageUpgraded(IPage page) => _page = page;


        public async Task ClickLoginButton()
        {
            await _page.RunAndWaitForNavigationAsync(async () =>
            {
                await _lnkLogin.ClickAsync();
            }, new PageRunAndWaitForNavigationOptions
            {
                UrlString = "**/Login"
            });
        }

        public async Task ClickEmployeeList()
        {
            await _lnkEmployeeLists.ClickAsync();
        }
        public async Task LogIn(string userName, string password)
        {
            await _txtUserName.FillAsync(userName);
            await _txtPassword.FillAsync(password);
            await _btnLogin.ClickAsync();
        }

        public async Task<bool> IsEmployeeDetailsExist() => await _lnkEmployeeDetails.IsVisibleAsync();
    }
}
