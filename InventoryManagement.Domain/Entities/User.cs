using InventoryManagement.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace InventoryManagement.Domain.Entities
{
    public class User : Auditor
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public virtual Member Member { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
