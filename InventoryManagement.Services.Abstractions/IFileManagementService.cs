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
        //return list of uploaded files paths
        Task<List<String>> uploadFiles(IFormFileCollection formFiles);
        
    }
}
