using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using PluraLeecher.MVP;

namespace PluraLeecher
{
    public partial class FrmMain : Form, IMainView
    {
        private readonly MainPresenter _presenter;
        public FrmMain()
        {
            InitializeComponent();
            _presenter = new MainPresenter(this);
        }

        public WebBrowser WebBrowser
        {
            get { return this.browser; }
        }
        public BindingList<Video> VideoTitleList { get; set; } 

        private void FormLoad(object sender, EventArgs e)
        {
            _presenter.Init();
            lstVideoTitle.DataSource = VideoTitleList;
        }

        private void Form1Closing(object sender, FormClosingEventArgs e)
        {
            _presenter.OnClosing();
        }

        private void LeechButtonClick(object sender, EventArgs e)
        {
            _presenter.StartLeech();
        }

    }

}
