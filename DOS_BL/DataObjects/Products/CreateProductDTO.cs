﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DOS_BL.DataObjects
{
    public class CreateProductDTO
    {
        [Required]
        [StringLength(255, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [StringLength(1023, ErrorMessage = "Description is too long.")]
        public string Description { get; set; }

        public List<int> ProcessIds { get; set; } = new();
    }
}
