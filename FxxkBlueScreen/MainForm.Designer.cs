namespace FxxkBlueScreen
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadingBrowser = new System.Windows.Forms.WebBrowser();
            this.HuajiBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // LoadingBrowser
            // 
            this.LoadingBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadingBrowser.IsWebBrowserContextMenuEnabled = false;
            this.LoadingBrowser.Location = new System.Drawing.Point(0, 0);
            this.LoadingBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.LoadingBrowser.Name = "LoadingBrowser";
            this.LoadingBrowser.ScriptErrorsSuppressed = true;
            this.LoadingBrowser.ScrollBarsEnabled = false;
            this.LoadingBrowser.Size = new System.Drawing.Size(1563, 1003);
            this.LoadingBrowser.TabIndex = 0;
            this.LoadingBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // HuajiBrowser
            // 
            this.HuajiBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HuajiBrowser.IsWebBrowserContextMenuEnabled = false;
            this.HuajiBrowser.Location = new System.Drawing.Point(0, 0);
            this.HuajiBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.HuajiBrowser.Name = "HuajiBrowser";
            this.HuajiBrowser.ScriptErrorsSuppressed = true;
            this.HuajiBrowser.ScrollBarsEnabled = false;
            this.HuajiBrowser.Size = new System.Drawing.Size(1563, 1003);
            this.HuajiBrowser.TabIndex = 1;
            this.HuajiBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1563, 1003);
            this.Controls.Add(this.HuajiBrowser);
            this.Controls.Add(this.LoadingBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.WebBrowser LoadingBrowser;
        public System.Windows.Forms.WebBrowser HuajiBrowser;
    }
}

