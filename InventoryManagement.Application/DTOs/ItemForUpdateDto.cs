using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class ItemForUpdateDto : IEntityDto
    {
        public ItemForUpdateDto()
        {
            WarehouseItems = new List<WarehouseItemForUpdateDto>();
            ItemImages = new List<ItemImageForUpdateDto>();
        }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Code is required")]
        [StringLength(5, ErrorMessage = "Code can't be longer than 5 characters")]
        public String Code { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public String Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be loner then 500 characters")]
        public String Description { get; set; }

        [StringLength(200, ErrorMessage = "Inroduction cannot be loner then 200 characters")]
        public String Inroduction { get; set; }
        public int MinPrice { get; set; }
        public int Price { get; set; }
        public int TotalQuantity { get; set; }
        public ItemType ItemType { get; set; }
        public bool? IsActive { get; set; } = true;

        public int ItemCategoryId { get; set; }
        public virtual ICollection<WarehouseItemForUpdateDto> WarehouseItems { get; set; }
        public virtual ICollection<ItemImageForUpdateDto> ItemImages { get; set; }

        //[Required(ErrorMessage = "Image is required")]
        public ICollection<IFormFile> filesOfImages { get; set; }
    }
}
