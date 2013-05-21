using System.Configuration;

namespace PluraLeecher
{
    public struct Strings
    {
        public const string WebBrowserStartAddress = "http://www.pluralsight.com";
        public const string UrlPrefix = "http://pluralsight.com/training/Player?";
        public struct Selectors
        {
            public const string LinkSelector = ".tocClips div";
            public const string HeaderSelector = ".left h1";
        }
        public struct AppConfig
        {
            public const string Path = "path";
        }
    }
}
