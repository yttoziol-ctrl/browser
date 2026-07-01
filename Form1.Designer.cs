namespace Ziolek_Browser
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnMenu = new Button();
            btnNewTab = new Button();
            btnHome = new Button();
            btnRefresh = new Button();
            btnForward = new Button();
            btnBookmark = new Button();
            txtAddress = new TextBox();
            btnBack = new Button();
            tabBrowser = new TabControl();
            browserHost = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(32, 32, 32);
            panel1.Controls.Add(btnMenu);
            panel1.Controls.Add(btnNewTab);
            panel1.Controls.Add(btnHome);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(btnForward);
            panel1.Controls.Add(btnBookmark);
            panel1.Controls.Add(txtAddress);
            panel1.Controls.Add(btnBack);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(1182, 48);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnMenu
            // 
            btnMenu.Location = new Point(1131, 14);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(39, 29);
            btnMenu.TabIndex = 4;
            btnMenu.Text = "☰";
            btnMenu.UseVisualStyleBackColor = true;
            // 
            // btnNewTab
            // 
            btnNewTab.Location = new Point(1041, 15);
            btnNewTab.Name = "btnNewTab";
            btnNewTab.Size = new Size(39, 29);
            btnNewTab.TabIndex = 3;
            btnNewTab.Text = "+";
            btnNewTab.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(147, 12);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(39, 29);
            btnHome.TabIndex = 2;
            btnHome.Text = "🏠";
            btnHome.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(102, 13);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(39, 29);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "⟳";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnForward
            // 
            btnForward.Location = new Point(57, 12);
            btnForward.Name = "btnForward";
            btnForward.Size = new Size(39, 29);
            btnForward.TabIndex = 2;
            btnForward.Text = "→";
            btnForward.UseVisualStyleBackColor = true;
            // 
            // btnBookmark
            // 
            btnBookmark.Location = new Point(1086, 15);
            btnBookmark.Name = "btnBookmark";
            btnBookmark.Size = new Size(39, 29);
            btnBookmark.TabIndex = 2;
            btnBookmark.Text = "⭐";
            btnBookmark.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(210, 15);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(825, 27);
            txtAddress.TabIndex = 1;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(39, 29);
            btnBack.TabIndex = 0;
            btnBack.Text = "←";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // tabBrowser
            // 
            tabBrowser.Dock = DockStyle.Top;
            tabBrowser.Location = new Point(0, 0);
            tabBrowser.Name = "tabBrowser";
            tabBrowser.SelectedIndex = 0;
            tabBrowser.Size = new Size(1182, 35);
            tabBrowser.TabIndex = 2;
            // 
            // browserHost
            // 
            browserHost.Dock = DockStyle.Fill;
            browserHost.Location = new Point(0, 83);
            browserHost.Name = "browserHost";
            browserHost.Size = new Size(1182, 570);
            browserHost.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 653);
            Controls.Add(browserHost);
            Controls.Add(panel1);
            Controls.Add(tabBrowser);
            MinimumSize = new Size(1200, 700);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ziolek Browser";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnBookmark;
        private TextBox txtAddress;
        private Button btnBack;
        private Button btnNewTab;
        private Button btnHome;
        private Button btnRefresh;
        private Button btnForward;
        private Button btnMenu;
        private TabControl tabBrowser;
        private Panel browserHost;
    }
}
