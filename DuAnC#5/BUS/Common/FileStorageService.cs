using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
namespace BUS.Common
{
    public class FileStorageService : IStorageService
    {
        private readonly string _userContentFolder;
        private const string USER_CONTENT_FOLDER_NAME = "Uploads";

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment == null)
            {
                throw new ArgumentNullException(nameof(webHostEnvironment));
            }

            if (string.IsNullOrEmpty(webHostEnvironment.WebRootPath))
            {
                webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            _userContentFolder = Path.Combine(webHostEnvironment.WebRootPath, USER_CONTENT_FOLDER_NAME);

            if (!Directory.Exists(_userContentFolder))
            {
                Directory.CreateDirectory(_userContentFolder);
            }
        }
        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public string GetFileUrl(string fileName)
        {
            return $"/{USER_CONTENT_FOLDER_NAME}/{fileName}"; 
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName), "File name cannot be null or empty.");
            }

            var filePath = Path.Combine(_userContentFolder, fileName);

            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }
    }
}
