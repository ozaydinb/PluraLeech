namespace PluraLeecher
{
    public interface IFile
    {
        string DownloadUrl { get; set; }
        string FileExtension { get; set; }
        string FolderName { get; set; }
        string Name { get; set; }
    }
}
