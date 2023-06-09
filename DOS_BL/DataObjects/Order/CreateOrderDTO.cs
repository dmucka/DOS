﻿using System.ComponentModel.DataAnnotations;

namespace DOS_BL.DataObjects
{
    public class CreateOrderDTO
    {
        [Required]
        [StringLength(255, ErrorMessage = "Serial Number is too long.")]
        public string SerialNumber { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Customer is too long.")]
        public string Customer { get; set; }

        [StringLength(1023, ErrorMessage = "Notes is too long.")]
        public string Notes { get; set; }

        [Required]
        public int? ProductId { get; set; }
    }
}
