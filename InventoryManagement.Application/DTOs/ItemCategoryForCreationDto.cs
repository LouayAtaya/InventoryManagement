using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class ItemCategoryForCreationDto: IEntityDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public String Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be loner then 500 characters")]
        public String Description { get; set; }

        public String Image { get; set; }

        public bool? IsActive { get; set; } = true;

        public int? ParentCategoryId { get; set; }

        public ICollection<ItemCategoryForCreationDto> ChildCategories { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
