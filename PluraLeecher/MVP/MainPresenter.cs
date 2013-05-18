using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Fiddler;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

namespace PluraLeecher.MVP
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly List<Video> _videoList;
        private readonly FileDownloader _fileDownloader;
        private int _currentVideoIndex;

        public MainPresenter(IMainView view)
        {
            _view = view;
            _videoList = new List<Video>();
            _fileDownloader = new FileDownloader();
            _fileDownloader.OnComplate += FileDownloaderOnComplate;
        }

        private void FileDownloaderOnComplate()
        {
            _currentVideoIndex++;
            _view.WebBrowser.Navigate(_videoList[_currentVideoIndex].PageUrl);
        }

        public void Init()
        {
            _view.VideoTitleList = new BindingList<Video>();
            FiddlerApplication.BeforeRequest += FiddlerApplicationBeforeRequest;
            CONFIG.IgnoreServerCertErrors = false;
            FiddlerApplication.Startup(80, true, true);
            _view.WebBrowser.Navigate(ConfigurationManager.AppSettings.Get("StartupUrl"));
        }

        private void FiddlerApplicationBeforeRequest(Session oSession)
        {
            if (oSession.url.EndsWith(".mp4") || oSession.url.EndsWith(".avi")
                    || oSession.url.EndsWith("wmv"))
            {
                if (!String.IsNullOrEmpty(_videoList[_currentVideoIndex].DownloadUrl))
                    return;
                _view.WebBrowser.Stop();
                _videoList[_currentVideoIndex].DownloadUrl = "http://" + oSession.url;
                _videoList[_currentVideoIndex].FileExtension = Path.GetExtension(oSession.url).Substring(1);
                _fileDownloader.DownloadFile(_videoList[_currentVideoIndex]);
            }
        }

        public void StartLeech()
        {
            _view.VideoTitleList.Clear();
            var html = new HtmlDocument();
            html.LoadHtml(_view.WebBrowser.DocumentText);
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
                _view.VideoTitleList.Add(video);
                _videoList.Add(video);
                videoCount++;
            }
            _currentVideoIndex = 0;
            _view.WebBrowser.Navigate(_videoList[0].PageUrl);
        }

        public void OnClosing()
        {
            FiddlerApplication.Shutdown();
        }
    }
}
