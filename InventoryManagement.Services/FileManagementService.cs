using InventoryManagement.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class FileManagementService : IFileManagementService
    {
        private readonly IConfiguration _config;

        public FileManagementService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<List<String>> uploadFiles(IFormFileCollection formFiles)
        {
            var folderName = _config["CategoryFileUpload"];
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (formFiles.Any(f => f.Length == 0))
            {
                throw new Exception("file length 0");
            }

            if (formFiles.Any(f =>
                Path.GetExtension(f.FileName).ToLower().Equals(".exe")))
            {
                throw new Exception("file is exe");

            }

            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }

            List<String> dbPaths = new List<String>();

            foreach (var formFile in formFiles)
            {
                var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                var fileNameWithOutExtension = Path.GetFileNameWithoutExtension(fileName);
                var fileExtension = Path.GetExtension(fileName);

                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                if (File.Exists(fullPath))
                {
                    int counter = 1;
                    string tempFileName = "";
                    while (File.Exists(fullPath))
                    {
                        tempFileName = fileNameWithOutExtension + "(" + counter + ")" + fileExtension;
                        fullPath = Path.Combine(pathToSave, tempFileName);
                        dbPath = Path.Combine(folderName, tempFileName);

                        counter++;
                    }
                }

                dbPaths.Add(dbPath);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }

            }
            return dbPaths;
        }
    }
}
