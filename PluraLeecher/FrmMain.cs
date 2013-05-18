using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PluraLeecher.MVP;

namespace PluraLeecher
{
    public partial class FrmMain : Form, IMainView
    {
        private readonly FrmMainPresenter _presenter;
        public FrmMain()
        {
            InitializeComponent();
            _presenter = new FrmMainPresenter(this);
        }

        delegate void UpdateUI();

        public WebBrowser WebBrowser
        {
            get { return this.browser; }
        }

        private List<string> _requestList;
        public List<string> RequestList
        {
            get
            {
                _requestList = new List<string>();
                foreach (string item in lstRequest.Items)
                {
                    _requestList.Add(item);
                }
                return _requestList;
            }
        }

        public void AddRequest(string requestAddress)
        {
            lstRequest.Invoke(new UpdateUI(() => lstRequest.Items.Add(requestAddress)));
        }

        public void ClearVideoTitleList()
        {
            lstVideoTitle.Items.Clear();
        }

        public void AddVideoTitle(Video video)
        {
            lstVideoTitle.Items.Add(video);
        }

        private void FormLoad(object sender, EventArgs e)
        {
            _presenter.Init();
        }

        private void ButtonClearClick(object sender, EventArgs e)
        {
            lstRequest.Items.Clear();
        }

        private void Form1Closing(object sender, FormClosingEventArgs e)
        {
            _presenter.OnClosing();
        }

        private void LeechButtonClick(object sender, EventArgs e)
        {
            _presenter.StartLeech();
        }

        private void ButtonNavigateBrowserClick(object sender, EventArgs e)
        {
            _presenter.NavigateBrowser(txtUrl.Text);
        }

        private void LstRequestClick(object sender, EventArgs e)
        {
            txtUrl.Text = lstRequest.SelectedItem.ToString();
        }

    }

}
