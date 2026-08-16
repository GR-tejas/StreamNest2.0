using System.IO;

namespace WebApplication1.Services
{
    public class MediaService
    {
        private readonly string baseFolderPath =  @"G:\Volume H stuff\LocalServerDedicatedFolder";

        public MediaResult? GetMedia(String path)
        {
            string filePath = Path.Combine(baseFolderPath, path);

            if(!File.Exists(filePath))
            {
                return null;
            }

            string contentType = GetContentType(filePath);

            return new MediaResult
            {
                FilePath = filePath,
                ContentType = contentType,
            };
        }

        public string GetContentType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            return extension switch
            {
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",

                ".mp4" => "video/mp4",
                ".webm" => "video/webm",
                ".mkv" => "video/x-matroska",

                _ => "application/octet-stream"
            };
        }
    }
}
