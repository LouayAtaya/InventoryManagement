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
        public async Task<string> UploadFile(IFormFile formFile, string folderName)
        {
            //var folderName = _config["CategoryFileUpload"];
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            HandleFormFileErrors(formFile);

            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }

            var savedFileName=await this.SaveFormFile(formFile, pathToSave);
            
            var fileDbPath = Path.Combine(folderName, savedFileName);

            return fileDbPath;
        }

        public async Task<List<String>> UploadFiles(IEnumerable<IFormFile> formFiles, string folderName)
        {
            //var folderName = _config["CategoryFileUpload"];
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            foreach(var formFile in formFiles)
            {
                this.HandleFormFileErrors(formFile);
            }

            #region 
            /*if (formFiles.Any(f => f.Length == 0))
            {
                throw new Exception("file length 0");
            }

            if (formFiles.Any(f =>
                Path.GetExtension(f.FileName).ToLower().Equals(".exe")))
            {
                throw new Exception("file is exe");

            } */
            #endregion

            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }

            List<String> dbPaths = new List<String>();

            foreach (var formFile in formFiles)
            {

                var dbPath = await this.SaveFormFile(formFile, pathToSave);

                dbPaths.Add(dbPath);
            }
            return dbPaths;
        }

        private void HandleFormFileErrors(IFormFile formFile)
        {
            if (formFile.Length == 0)
            {
                throw new Exception("file length 0");
            }

            if (Path.GetExtension(formFile.FileName).ToLower().Equals(".exe"))
            {
                throw new Exception("file is exe");
            }
        }

        private async Task<string> SaveFormFile(IFormFile formFile, string pathToSave)
        {
            var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
            var fileNameWithOutExtension = Path.GetFileNameWithoutExtension(fileName);
            var fileExtension = Path.GetExtension(fileName);

            var fullPath = Path.Combine(pathToSave, fileName);

            if (File.Exists(fullPath))
            {
                int counter = 1;
                
                while (File.Exists(fullPath))
                {
                    fileName = fileNameWithOutExtension + "(" + counter + ")" + fileExtension;
                    fullPath = Path.Combine(pathToSave, fileName);

                    counter++;
                }
            }

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return fileName;
        }



    }
}
