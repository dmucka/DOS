﻿using DOS_BL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DOS_BL.DataObjects
{
    public class EditOrderDTO : IEditDTO, ITrackEditDTO, ITrackCreateDTO, ISoftDeleteDTO
    {
        [Key]
        [Editable(false)]
        public int Id { get; set; }

        [Editable(false)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Status is too long.")]
        public string Status { get; set; }

        [Editable(false)]
        [Required]
        [StringLength(255, ErrorMessage = "Serial Number is too long.")]
        public string SerialNumber { get; set; }

        [Editable(false)]
        [Required]
        [StringLength(255, ErrorMessage = "Customer is too long.")]
        public string Customer { get; set; }

        [StringLength(1023, ErrorMessage = "Notes is too long.")]
        public string Notes { get; set; }

        [Editable(false)]
        public DateTime Created { get; set; }

        [Editable(false)]
        public string CreatedByUsername { get; set; }

        [Editable(false)]
        public string CreatedText => $"{Created} by {CreatedByUsername}";

        [Editable(false)]
        public DateTime Edited { get; set; }

        [Editable(false)]
        public string EditedByUsername { get; set; }

        [Editable(false)]
        public string EditedText => $"{Edited} by {EditedByUsername}";

        public bool IsDeleted { get; set; }

        public List<EditManufacturingStepDTO> ManufacturingSteps { get; set; }
    }
}
