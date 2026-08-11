namespace WebApplication1.DTO
{
    public class DirectoryContentsDto
    {
        public string Name { get; set; } = string.Empty;
        public List<FolderDto> Folders { get; set; } = new();
        public List<FileDto> Files { get; set; } = new();
    }
}
