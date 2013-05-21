using System;
using System.Collections.Generic;

namespace PluraLeecher.Models
{
    [Serializable]
    public class Course
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public List<Video> VideoList { get; set; }

        public string FolderName { get; set; }
    }
}
