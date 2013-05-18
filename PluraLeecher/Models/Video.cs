namespace PluraLeecher.Models
{
    public class Video: IFile
    {
        public string PageUrl { get; set; }
        public string DownloadUrl { get; set; }
        public string Name { get; set; }
        public string FolderName { get; set; }
        public bool IsComplated { get; set; }
        public string FileExtension { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
