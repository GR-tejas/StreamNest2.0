using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;

namespace WebApplication1.Services
{
    public class DirectoryService
    {
        //string baseFolderPath = @"C:\Users\wasis\Desktop\LocalServerFolder";
        string baseFolderPath = @"G:\Volume H stuff\LocalServerDedicatedFolder";
        public DirectoryContentsDto GetFolderContents(String path = "")
        {
            String FolderPath = Path.Combine(baseFolderPath, path);

            var directoryInfo = new DirectoryInfo(FolderPath);

            var response = new DirectoryContentsDto
            {
                Name = directoryInfo.Name,
                Folders = directoryInfo.GetDirectories().Select(folder => new FolderDto
                {
                    Name = folder.Name
                }).ToList(),
                Files = directoryInfo.GetFiles().Select(file => new FileDto
                {
                    Name = file.Name,
                    Extension = file.Extension
                }).ToList()
            };

            return (response);
        }
    }
}
