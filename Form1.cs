using Ziolek_Browser.Browser;

namespace Ziolek_Browser
{
    public partial class MainForm : Form
    {
        private readonly BrowserManager browserManager = new();
        private BrowserEngine? browser;

        public MainForm()
        {
            InitializeComponent();

            Load += MainForm_Load;

            btnNewTab.Click += btnNewTab_Click;
            tabBrowser.SelectedIndexChanged += tabBrowser_SelectedIndexChanged;
            tabBrowser.MouseDown += tabBrowser_MouseDown;

            txtAddress.KeyDown += txtAddress_KeyDown;

            btnBack.Click += (_, _) => browser?.Back();
            btnForward.Click += (_, _) => browser?.Forward();
            btnRefresh.Click += (_, _) => browser?.Reload();
            btnHome.Click += (_, _) => browser?.Home();
        }

        private async void MainForm_Load(object? sender, EventArgs e)
        {
            await CreateNewTabAsync();
        }

        private async Task CreateNewTabAsync()
        {
            BrowserTab tab = browserManager.CreateTab();
            await tab.InitializeAsync();

            tab.Engine.AddressChanged += address =>
            {
                if (browserManager.CurrentTab == tab)
                    Browser_AddressChanged(address);
            };

            tab.Engine.TitleChanged += title =>
            {
                UpdateTabTitle(tab, title);
            };

            browserHost.Controls.Add(tab.Browser);
            tab.Browser.Visible = false;

            TabPage page = new("Nowa karta")
            {
                Tag = tab,
                ToolTipText = "Nowa karta"
            };

            tabBrowser.TabPages.Add(page);
            tabBrowser.SelectedTab = page;
        }

        private void CloseTab(BrowserTab tab)
        {
            if (!browserManager.CanCloseTab)
                return;

            TabPage? page = tabBrowser.TabPages
                .Cast<TabPage>()
                .FirstOrDefault(p => ReferenceEquals(p.Tag, tab));

            if (page == null)
                return;

            int index = tabBrowser.TabPages.IndexOf(page);

            browserHost.Controls.Remove(tab.Browser);
            tab.Browser.Dispose();

            browserManager.CloseTab(tab);
            tabBrowser.TabPages.Remove(page);

            if (tabBrowser.TabPages.Count == 0)
                return;

            tabBrowser.SelectedIndex = Math.Max(0, index - 1);
        }

        private void tabBrowser_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Middle)
                return;

            for (int i = 0; i < tabBrowser.TabPages.Count; i++)
            {
                if (!tabBrowser.GetTabRect(i).Contains(e.Location))
                    continue;

                if (tabBrowser.TabPages[i].Tag is BrowserTab tab)
                    CloseTab(tab);

                break;
            }
        }

        private void UpdateTabTitle(BrowserTab tab, string title)
        {
            if (InvokeRequired)
            {
                Invoke(() => UpdateTabTitle(tab, title));
                return;
            }

            tab.Title = title;

            foreach (TabPage page in tabBrowser.TabPages)
            {
                if (!ReferenceEquals(page.Tag, tab))
                    continue;

                page.Text = string.IsNullOrWhiteSpace(title) ? "Nowa karta" : title;
                page.ToolTipText = title;
                break;
            }

            if (browserManager.CurrentTab == tab)
                Text = $"{title} - Ziolek Browser";
        }

        private async void btnNewTab_Click(object? sender, EventArgs e)
        {
            await CreateNewTabAsync();
        }

        private void tabBrowser_SelectedIndexChanged(object? sender, EventArgs e)
        {
            foreach (Control c in browserHost.Controls)
                c.Visible = false;

            if (tabBrowser.SelectedTab?.Tag is not BrowserTab tab)
                return;

            browserManager.SetCurrentTab(tab);
            browser = tab.Engine;

            tab.Browser.Visible = true;
            tab.Browser.BringToFront();

            txtAddress.Text = tab.Browser.Source?.ToString() ?? "";
            Text = $"{tab.Title} - Ziolek Browser";
        }

        private void Browser_AddressChanged(string address)
        {
            if (InvokeRequired)
            {
                Invoke(() => Browser_AddressChanged(address));
                return;
            }

            txtAddress.Text = address;
        }

        private void txtAddress_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                browser?.Navigate(txtAddress.Text);
                e.SuppressKeyPress = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
