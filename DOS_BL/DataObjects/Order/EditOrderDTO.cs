using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.DataObjects.Order
{
    // TODO
    class EditOrderDTO
    {
        [Required]
        [StringLength(255, ErrorMessage = "Serial Number is too long.")]
        public string SerialNumber { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Customer is too long.")]
        public string Customer { get; set; }

        [StringLength(1023, ErrorMessage = "Notes is too long.")]
        public string Notes { get; set; }

        public DateTime Edited { get; set; }
    }
}
