using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Abstractions
{
    public interface IFileManagementService
    {
        //return uploaded file paths
        Task<String> UploadFile(IFormFile formFiles, string folderName);

        //return list of uploaded files paths
        Task<List<String>> UploadFiles(IEnumerable<IFormFile> formFile, string folderName);

    }
}
