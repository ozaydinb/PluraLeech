using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Fiddler;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using PluraLeecher.Abstraction;
using PluraLeecher.Helpers;
using PluraLeecher.Models;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace PluraLeecher
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private List<Video> _videoList;
        private readonly DownloadHelper _downloadHelper;
        private int _currentVideoIndex;
        private int _categoryIndex = 0;
        private int _courseIndex = 0;
        private Course _currentCourse;
        private List<CourseCategory> _categories;
        private readonly SerializerHelper _serializerHelper;
       
        public MainPresenter(IMainView view)
        {
            _view = view;
            _videoList = new List<Video>();
            _downloadHelper = new DownloadHelper();
            _serializerHelper = new SerializerHelper();
            _downloadHelper.OnComplate += DownloadHelperOnComplate;
        }

        private void DownloadHelperOnComplate()
        {
            _videoList[_currentVideoIndex].IsComplated = true;
            _serializerHelper.SerializeToFile(_videoList);
            _currentVideoIndex++;
            _view.WebBrowser.Navigate(_videoList[_currentVideoIndex].PageUrl);
        }

        public void Init()
        {
           
            _view.VideoTitleList = new BindingList<Video>();
            _view.WebBrowser.ScriptErrorsSuppressed = true;
            FiddlerApplication.BeforeRequest += FiddlerApplicationBeforeRequest;
            CONFIG.IgnoreServerCertErrors = false;
            FiddlerApplication.Startup(0, true, true);
            var resumeVideos = _serializerHelper.DeserializeFromFile<List<Video>>();
            if (resumeVideos != null)
            {
                var currentVideoIndex = resumeVideos.Count(video => video.IsComplated);
                _currentVideoIndex = currentVideoIndex;
                _videoList = resumeVideos;
                _view.WebBrowser.Navigate(_videoList[_currentVideoIndex].PageUrl);
                return;
            }
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
                _downloadHelper.DownloadFile(_videoList[_currentVideoIndex]);
            }
        }

        public void DownThemAll()
        {
            _view.WebBrowser.Navigated += WebBrowserNavigated;
            _categories = GetCourseList();
            GetNext();
        }

        public void DownloadSelectedPageVideos()
        {
            _view.VideoTitleList.Clear();
            _videoList.AddRange(GetVideoList());
            foreach (Video video in _videoList)
            {
                _view.VideoTitleList.Add(video);
            }
            _currentVideoIndex = 0;
            _view.WebBrowser.Navigate(_videoList[0].PageUrl);
        }

        private void WebBrowserNavigated(object o, WebBrowserNavigatedEventArgs e)
        {
            if (_currentCourse == null)
                return;
            if (e.Url.AbsoluteUri != _currentCourse.Url)
                return;
            _currentCourse.VideoList = GetVideoList();
            _videoList.AddRange(_currentCourse.VideoList);
            GetNext();
        }

        private void GetNext()
        {
            if (_categories[_categoryIndex].CourseList.Count <= _courseIndex)
            {
                _courseIndex = 0;
                _categoryIndex++;
                if (_categories.Count <= _categoryIndex)
                {
                    _currentCourse = null;
                    _currentVideoIndex = 0;
                    _view.WebBrowser.Navigate(_videoList[0].PageUrl);
                    var serializer = new SerializerHelper();
                    serializer.SerializeToFile(_videoList);

                    return;
                }
            }
            _currentCourse = _categories[_categoryIndex].CourseList[_courseIndex];
            _currentCourse.FolderName = string.Format(@"{0}\{1}", _categories[_categoryIndex].Name.RemoveSlashAndBackSlash(),
                                                      _currentCourse.Name.RemoveSlashAndBackSlash());
            _view.WebBrowser.Navigate(_categories[_categoryIndex].CourseList[_courseIndex].Url);
            _courseIndex++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Video> GetVideoList()
        {
            _view.VideoTitleList.Clear();
            var html = new HtmlDocument();
            html.LoadHtml(_view.WebBrowser.DocumentText);
            var document = html.DocumentNode;
            var selectorResult = document.QuerySelectorAll(Strings.Selectors.LinkSelector);
            string folderName = "";
            var folderNameNode = document.QuerySelector(Strings.Selectors.HeaderSelector);
            if (folderNameNode != null)
            {
                folderName = folderNameNode.InnerText;
            }
            if (_currentCourse != null)
            {
                folderName = _currentCourse.FolderName;
            }

            int videoCount = 1;
            var videoList = new List<Video>();
            foreach (HtmlNode htmlNode in selectorResult)
            {
                try
                {
                    var video = new Video();
                    // Hata aldığımız yer 
                    string rawUrl = htmlNode.QuerySelector("a").Attributes["ng-click"].Value;
                    //TODO Salih: NullReferanceException verebilir! Sonrasında düzeltilebilir.
                    string baseUrl = Regex.Match(rawUrl,@"'([^']*)").Groups.SyncRoot.ToString().Substring(1);
                    string extensionUrl = Regex.Match(rawUrl, @"'([^']*)")
                        .NextMatch()
                        .NextMatch()
                        .Groups.SyncRoot.ToString().Substring(1).Replace("amp;","");

                    var pageUrl = baseUrl + @"/Player?" + extensionUrl;
                             //.Value.Substring(1)
                             //.Replace("amp;", "");
                    //var geleniataoyala = match;
                    var videoName = htmlNode.QuerySelector("a").InnerText.RemoveSlashAndBackSlash();
                    video.PageUrl = pageUrl;
                    //video.PageUrl = string.Format("{0}{1}", Strings.UrlPrefix, pageUrl);
                    video.Name = string.Format("{0}-{1}", videoCount, videoName);
                    video.FolderName = folderName;
                    videoList.Add(video);
                    videoCount++;
                }
                catch (Exception exp)
                {

                    videoCount++;
                }

            }
            return videoList;
        }

        public void OnClosing()
        {
            FiddlerApplication.Shutdown();
        }

        private List<CourseCategory> GetCourseList()
        {
            var html = new HtmlDocument();
            html.LoadHtml(_view.WebBrowser.DocumentText);
            var document = html.DocumentNode;
            var categoryHeaders = document.QuerySelectorAll(".categoryHeader");
            var courseCategories = new List<CourseCategory>();
            foreach (var categoryHeader in categoryHeaders)
            {
                var courseList = new List<Course>();
                var courseCategory = new CourseCategory();
                courseCategory.Id = categoryHeader.Id;
                courseCategory.Name = categoryHeader.QuerySelector(".title").InnerText.Trim();
                var courseNodeList = (document.QuerySelector(String.Format("#{0}", courseCategory.Id)).NextSibling).NextSibling.QuerySelectorAll("td.title");
                foreach (var node in courseNodeList)
                {
                    var course = new Course();
                    course.Url = String.Format("{0}{1}", "http://www.pluralsight.com", node.QuerySelector("a").Attributes["href"].Value);
                    course.Name = node.QuerySelector("a").InnerText.Trim();
                    courseList.Add(course);
                }
                courseCategory.CourseList = courseList;
                courseCategories.Add(courseCategory);
            }
            return courseCategories;
        }
    }
}
