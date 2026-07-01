using Microsoft.Web.WebView2.WinForms;

namespace Ziolek_Browser.Browser
{
    public class BrowserTab
    {
        // Nazwa wyświetlana na karcie
        public string Title { get; set; } = "Nowa karta";

        // Silnik przeglądarki dla tej karty
        public BrowserEngine Engine { get; }

        // Kontrolka WebView2
        public WebView2 Browser => Engine.Browser;

        // Informacja czy karta została już zainicjalizowana
        public bool IsInitialized { get; private set; }

        public BrowserTab()
        {
            WebView2 webView = new WebView2
            {
                Dock = DockStyle.Fill
            };

            Engine = new BrowserEngine(webView);
        }

        public async Task InitializeAsync()
        {
            if (IsInitialized)
                return;

            await Engine.InitializeAsync();

            Engine.Home();

            IsInitialized = true;
        }

        public void Navigate(string address)
        {
            Engine.Navigate(address);
        }

        public void Back()
        {
            Engine.Back();
        }

        public void Forward()
        {
            Engine.Forward();
        }

        public void Reload()
        {
            Engine.Reload();
        }

        public void Home()
        {
            Engine.Home();
        }
    }
}