using InventoryManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities.Parameters
{
    public class ItemParameters:QueryStringParameters
    {
        public ItemParameters() 
        {
            OrderBy = "CreatedAt desc";
        }

        public int? ItemCategoryId { get; set; }

        public uint MinPrice { get; set; }
        public uint? MaxPrice { get; set; }

        public bool ValidPriceRange => (!MaxPrice.HasValue || MaxPrice >= MinPrice);

        public uint MinQuantity { get; set; }
        public uint? MaxQuantity { get; set; }

        public bool ValidQuantity => (!MaxQuantity.HasValue || MaxQuantity >= MinQuantity);

        public bool? IsActive { get; set; }

        public ItemType? ItemType { get; set; }

        public string SearchTerm { get; set; }

    }
}
