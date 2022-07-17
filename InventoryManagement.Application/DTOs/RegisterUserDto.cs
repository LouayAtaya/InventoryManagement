using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class RegisterUserDto: IEntityDto
    {
        public RegisterUserDto()
        {
            UserRoles = new List<UserRoleForCreationDto>();

        }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(256, ErrorMessage = "UserName can't be longer than 256 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(256, ErrorMessage = "Email can't be longer than 256 characters")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Phone Number can't be longer than 150 characters")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public virtual MemberForCreationDto Member { get; set; }
        public virtual ICollection<UserRoleForCreationDto> UserRoles { get; set; }

        public bool? IsActive { get; set; }
    }
}
