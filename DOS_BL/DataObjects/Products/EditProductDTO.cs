﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.DataObjects
{
    public class EditProductDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [StringLength(1023, ErrorMessage = "Description is too long.")]
        public string Description { get; set; }
    }
}