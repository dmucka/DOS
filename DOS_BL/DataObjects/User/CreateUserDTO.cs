using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.DataObjects
{
    public class CreateUserDTO
    {
        [Required]
        [StringLength(255, ErrorMessage = "Username is too long.")]
        public string Username { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Password is too long")]
        public string Password { get; set; }

        [StringLength(255, ErrorMessage = "First name is too long")]
        public string FirstName { get; set; }

        [StringLength(255, ErrorMessage = "Last name is too long")]
        public string LastName { get; set; }

        [EmailAddress]
        [StringLength(255, ErrorMessage = "Email is too long")]
        public string Email { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
