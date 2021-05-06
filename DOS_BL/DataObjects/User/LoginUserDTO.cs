using System.ComponentModel.DataAnnotations;

namespace DOS_BL.DataObjects
{
    public class LoginUserDTO
    {
        [Required]
        [StringLength(255, ErrorMessage = "Username is too long.")]
        public string Username { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Password is too long")]
        public string Password { get; set; }
    }
}
