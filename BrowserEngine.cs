using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace Ziolek_Browser.Browser
{
    public class BrowserEngine
    {
        private readonly WebView2 browser;

        public WebView2 Browser => browser;

        public event Action<string>? AddressChanged;
        public event Action<string>? TitleChanged;

        public BrowserEngine(WebView2 browser)
        {
            this.browser = browser;
        }

        public async Task InitializeAsync()
        {
            if (browser.CoreWebView2 != null)
                return;

            await browser.EnsureCoreWebView2Async();

            browser.CoreWebView2.NavigationCompleted += NavigationCompleted;
            browser.CoreWebView2.DocumentTitleChanged += DocumentTitleChanged;
            browser.CoreWebView2.SourceChanged += SourceChanged;
        }

        private void NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (browser.CoreWebView2 == null)
                return;

            AddressChanged?.Invoke(browser.Source.ToString());
            TitleChanged?.Invoke(browser.CoreWebView2.DocumentTitle);
        }

        private void DocumentTitleChanged(object? sender, object e)
        {
            if (browser.CoreWebView2 == null)
                return;

            TitleChanged?.Invoke(browser.CoreWebView2.DocumentTitle);
        }

        private void SourceChanged(object? sender, CoreWebView2SourceChangedEventArgs e)
        {
            AddressChanged?.Invoke(browser.Source.ToString());
        }

        public void Navigate(string input)
        {
            if (browser.CoreWebView2 == null)
                return;

            if (string.IsNullOrWhiteSpace(input))
                return;

            input = input.Trim();

            if (!input.StartsWith("http://") &&
                !input.StartsWith("https://"))
            {
                if (input.Contains("."))
                {
                    input = "https://" + input;
                }
                else
                {
                    input = "https://www.google.com/search?q=" +
                            Uri.EscapeDataString(input);
                }
            }

            browser.CoreWebView2.Navigate(input);
        }

        public void Back()
        {
            if (browser.CanGoBack)
                browser.GoBack();
        }

        public void Forward()
        {
            if (browser.CanGoForward)
                browser.GoForward();
        }

        public void Reload()
        {
            browser.Reload();
        }

        public void Home()
        {
            Navigate("https://www.google.com");
        }
    }
}