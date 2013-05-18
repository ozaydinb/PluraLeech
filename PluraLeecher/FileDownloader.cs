using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;

namespace PluraLeecher
{
    public class FileDownloader
    {
        public delegate void DownloadComplate();
        public event DownloadComplate OnComplate;
        private string _rootPath;
        private string RootPath
        {
            get
            {
                if (string.IsNullOrEmpty(_rootPath))
                {
                    _rootPath = ConfigurationManager.AppSettings.Get(Strings.AppConfig.Path);
                }
                return _rootPath;
            }
        }

        public void DownloadFile(IFile file)
        {

            using (var client = new WebClient())
            {
                var url = new Uri(file.DownloadUrl);
                var filePath = string.Format(@"{0}\{1}\{2}.{3}", RootPath, file.FolderName.DeleteIllegalCharacters(), file.Name.DeleteIllegalCharacters(), file.FileExtension);
                var directoryPath = String.Format(@"{0}\{1}", RootPath, file.FolderName);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                if (!File.Exists(filePath))
                {
                    client.DownloadFile(url, filePath);
                }
                OnComplate();
            }
        }
    }
}
