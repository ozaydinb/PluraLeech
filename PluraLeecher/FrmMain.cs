using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Fizzler.Systems.HtmlAgilityPack;
using PluraLeecher.MVP;
using PluraLeecher.Models;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

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
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

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
            _presenter.DownloadSelectedPageVideos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.DownThemAll();

        }

    }



}
