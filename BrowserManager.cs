using System.Collections.Generic;

namespace Ziolek_Browser.Browser
{
    public class BrowserManager
    {
        private readonly List<BrowserTab> tabs = new();

        public IReadOnlyList<BrowserTab> Tabs => tabs;
        public BrowserTab? CurrentTab { get; private set; }

        public bool CanCloseTab => tabs.Count > 1;

        public BrowserTab CreateTab()
        {
            BrowserTab tab = new BrowserTab();
            tabs.Add(tab);
            CurrentTab = tab;
            return tab;
        }

        public void SetCurrentTab(BrowserTab tab)
        {
            CurrentTab = tab;
        }

        public int IndexOf(BrowserTab tab)
        {
            return tabs.IndexOf(tab);
        }

        public void CloseTab(BrowserTab tab)
        {
            if (!tabs.Remove(tab))
                return;

            if (CurrentTab == tab)
                CurrentTab = tabs.Count > 0 ? tabs[^1] : null;
        }
    }
}
