using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class ItemImageDto : IEntityDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Url { get; set; }

   }
}
