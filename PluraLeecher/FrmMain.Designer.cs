namespace PluraLeecher
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.browser = new System.Windows.Forms.WebBrowser();
            this.lstVideoTitle = new System.Windows.Forms.ListBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnNavigateBrowser = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLeech = new System.Windows.Forms.Button();
            this.lstRequest = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // browser
            // 
            this.browser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browser.Location = new System.Drawing.Point(228, 38);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(720, 285);
            this.browser.TabIndex = 0;
            // 
            // lstVideoTitle
            // 
            this.lstVideoTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstVideoTitle.FormattingEnabled = true;
            this.lstVideoTitle.Location = new System.Drawing.Point(12, 38);
            this.lstVideoTitle.Name = "lstVideoTitle";
            this.lstVideoTitle.Size = new System.Drawing.Size(210, 394);
            this.lstVideoTitle.TabIndex = 1;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(12, 12);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(322, 20);
            this.txtUrl.TabIndex = 2;
            // 
            // btnNavigateBrowser
            // 
            this.btnNavigateBrowser.Location = new System.Drawing.Point(340, 10);
            this.btnNavigateBrowser.Name = "btnNavigateBrowser";
            this.btnNavigateBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnNavigateBrowser.TabIndex = 3;
            this.btnNavigateBrowser.Text = "Aç";
            this.btnNavigateBrowser.UseVisualStyleBackColor = true;
            this.btnNavigateBrowser.Click += new System.EventHandler(this.ButtonNavigateBrowserClick);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(867, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.ButtonClearClick);
            // 
            // btnLeech
            // 
            this.btnLeech.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeech.Location = new System.Drawing.Point(786, 9);
            this.btnLeech.Name = "btnLeech";
            this.btnLeech.Size = new System.Drawing.Size(75, 23);
            this.btnLeech.TabIndex = 5;
            this.btnLeech.Text = "Sömür";
            this.btnLeech.UseVisualStyleBackColor = true;
            this.btnLeech.Click += new System.EventHandler(this.LeechButtonClick);
            // 
            // lstRequest
            // 
            this.lstRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRequest.FormattingEnabled = true;
            this.lstRequest.Location = new System.Drawing.Point(228, 329);
            this.lstRequest.Name = "lstRequest";
            this.lstRequest.Size = new System.Drawing.Size(720, 108);
            this.lstRequest.TabIndex = 6;
            this.lstRequest.Click += new System.EventHandler(this.LstRequestClick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 440);
            this.Controls.Add(this.lstRequest);
            this.Controls.Add(this.btnLeech);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnNavigateBrowser);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lstVideoTitle);
            this.Controls.Add(this.browser);
            this.Name = "FrmMain";
            this.Text = "PluraLeech";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1Closing);
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.ListBox lstVideoTitle;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnNavigateBrowser;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnLeech;
        private System.Windows.Forms.ListBox lstRequest;
    }
}

