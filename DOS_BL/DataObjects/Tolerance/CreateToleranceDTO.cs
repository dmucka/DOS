using System;
using System.ComponentModel.DataAnnotations;

namespace DOS_BL.DataObjects
{
    public class CreateToleranceDTO
    {
        [Required]
        [StringLength(255, ErrorMessage = "Value name is too long.")]
        public string ValueName { get; set; }

        [Required]
        [Range(-9999.9999, 9999.9999, ErrorMessage = "Max value overflows.")]
        public decimal MaxValue { get; set; }

        [Required]
        [Range(-9999.9999, 9999.9999, ErrorMessage = "Min value overflows.")]
        public decimal MinValue { get; set; }

        [Required]
        public int? ProductId { get; set; }

        [Required]
        public int? ProcessId { get; set; }
    }
}
