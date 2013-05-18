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
            this.btnLeech = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.browser.Size = new System.Drawing.Size(720, 394);
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
            // btnLeech
            // 
            this.btnLeech.Location = new System.Drawing.Point(12, 9);
            this.btnLeech.Name = "btnLeech";
            this.btnLeech.Size = new System.Drawing.Size(75, 23);
            this.btnLeech.TabIndex = 5;
            this.btnLeech.Text = "Sömür";
            this.btnLeech.UseVisualStyleBackColor = true;
            this.btnLeech.Click += new System.EventHandler(this.LeechButtonClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Down Them All!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 440);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLeech);
            this.Controls.Add(this.lstVideoTitle);
            this.Controls.Add(this.browser);
            this.Name = "FrmMain";
            this.Text = "PluraLeech";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1Closing);
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.ListBox lstVideoTitle;
        private System.Windows.Forms.Button btnLeech;
        private System.Windows.Forms.Button button1;
    }
}

