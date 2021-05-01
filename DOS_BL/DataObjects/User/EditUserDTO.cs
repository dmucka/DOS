using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.DataObjects
{
    public class EditUserDTO : CreateUserDTO
    {
        [Required]
        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "Password is too long")]
        public new string Password { get; set; }
    }
}
