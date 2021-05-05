using DOS_BL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.DataObjects
{
    public class EditUserDTO : CreateUserDTO, IEditDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "Password is too long")]
        public new string Password { get; set; }
    }
}
