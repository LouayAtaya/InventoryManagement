using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class ItemImageForCreationDto : IEntityDto
    {
        [StringLength(50, ErrorMessage = "Image Name can't be longer than 50 characters")]
        public String Name { get; set; }

        [StringLength(500, ErrorMessage = "Image Description can't be longer than 500 characters")]
        public String Description { get; set; }

        public String Url { get; set; }
    }
}
