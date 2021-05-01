using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.DataObjects
{
    public class EditToleranceDTO : CreateToleranceDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
