using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class UserForUpdateDto : IEntityDto
    {
        public UserForUpdateDto()
        {
            UserRoles = new List<UserRoleForUpdateDto>();

        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username can't be longer than 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(150, ErrorMessage = "Email can't be longer than 150 characters")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Mobile can't be longer than 150 characters")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Password can't be longer than 50 characters")]
        public string Password { get; set; }

        public virtual MemberForUpdateDto Member { get; set; }
        public virtual ICollection<UserRoleForUpdateDto> UserRoles { get; set; }

        public bool IsActive { get; set; }
    }
}
