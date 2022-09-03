using Microsoft.Playwright;

namespace EasyRestPlaywrightSpecflowProject.Drivers
{
    public class Driver : IDisposable
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;

        public Driver()
        {
            _page = InintializePlaywright();
        }

        public IPage Page => _page.Result;


        private async Task<IPage> InintializePlaywright()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            return await _browser.NewPageAsync();
        }

        public void Dispose() => _browser?.CloseAsync();

    }
}
