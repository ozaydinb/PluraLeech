using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Fiddler;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

namespace PluraLeecher
{
    public partial class FrmMain : Form
    {
        delegate void UpdateUI();

        private delegate void UpdateDownloadStatus();

        public int CurrentVideoIndex;
        public List<Video> VideoList;
        public FileDownloader Downloader;
        public FrmMain()
        {
            InitializeComponent();
            VideoList = new List<Video>();
            Downloader = new FileDownloader();
            Downloader.OnComplate += _downloader_OnComplate;
        }

        void _downloader_OnComplate()
        {
            CurrentVideoIndex++;
            webBrowser1.Navigate(VideoList[CurrentVideoIndex].PageUrl);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FiddlerApplication.BeforeRequest += FiddlerApplication_BeforeRequest;

            CONFIG.IgnoreServerCertErrors = false;
            FiddlerApplication.Startup(80, true, true);
            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
            webBrowser1.Navigate(Strings.WebBrowserStartAddress);

            button3.Enabled = false;
        }

        void FiddlerApplication_BeforeRequest(Session oSession)
        {

            lstRequest.Invoke(new UpdateUI(() => lstRequest.Items.Add(oSession.url)));

            if (oSession.url.EndsWith(".mp4") || oSession.url.EndsWith(".avi")
                    || oSession.url.EndsWith("wmv"))
            {
                if (!String.IsNullOrEmpty(VideoList[CurrentVideoIndex].DownloadUrl))
                    return;
                webBrowser1.Stop();
                VideoList[CurrentVideoIndex].DownloadUrl = "http://" + oSession.url;
                VideoList[CurrentVideoIndex].FileExtension = Path.GetExtension(oSession.url).Substring(1);
                Downloader.DownloadFile(VideoList[CurrentVideoIndex]);
            }
        }


        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lstRequest.Items.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FiddlerApplication.Shutdown();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(webBrowser1.DocumentText);
            var document = html.DocumentNode;
            var selectorResult = document.QuerySelectorAll(Strings.Selectors.LinkSelector);
            var folderName = document.QuerySelectorAll(Strings.Selectors.HeaderSelector).FirstOrDefault().InnerHtml;
            string urlPrefix = Strings.UrlPrefix;
            int videoCount = 1;
            foreach (HtmlNode htmlNode in selectorResult)
            {
                string raw = htmlNode.InnerHtml.Substring(htmlNode.InnerHtml.IndexOf("LaunchSelectedPlayer") + 20);
                var video = new Video();
                var pageUrl = Regex.Match(raw, @"'([^']*)").Value.Substring(1).Replace("amp;", "");
                video.PageUrl = string.Format("{0}{1}", urlPrefix, pageUrl);
                video.Name = string.Format("{0}-{1}", videoCount, Regex.Match(raw, @">([^<]*)").Value.Substring(1));
                video.FolderName = folderName;
                listBox1.Items.Add(video);
                VideoList.Add(video);
                videoCount++;
            }
            CurrentVideoIndex = 0;
            webBrowser1.Navigate(VideoList[0].PageUrl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
        }

        private void listBox2_Click(object sender, EventArgs e)
        {
            textBox1.Text = lstRequest.SelectedItem.ToString();
        }

    }

}
