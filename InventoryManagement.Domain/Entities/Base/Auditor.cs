using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagement.Domain.Entities.Base
{
    public class Auditor:BaseEntity
    {
        public Auditor()
        {
            this.IsActive = true;
            this.CreatedAt = DateTime.Now;
        }

        [DefaultValue(true)]
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } 

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; } 

        public int? UpdatedBy { get; set; }

        public DateTime? DeActivatedAt { get; set; }
        public int? DeActivatedBy { get; set; }
    }
}
