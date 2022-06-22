﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class RoleForCreationDto
    {
        public RoleForCreationDto()
        {
            RolePrivileges = new List<RolePrivilegeForCreationDto>();
        }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public String Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be longer then 500 characters")]
        public String Description { get; set; }

        public virtual ICollection<RolePrivilegeForCreationDto> RolePrivileges { get; set; }

        public bool IsActive { get; set; }
    }
}
