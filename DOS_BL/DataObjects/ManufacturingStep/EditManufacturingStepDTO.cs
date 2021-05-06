using DOS_BL.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace DOS_BL.DataObjects
{
    public class EditManufacturingStepDTO : IEditDTO, ITrackEditDTO
    {
        [Key]
        [Editable(false)]
        public int Id { get; set; }

        [Editable(false)]
        public string ProcessName { get; set; }

        [Range(-9999.9999, 9999.9999, ErrorMessage = "Wavelength overflows.")]
        public decimal Wavelength { get; set; }

        [Range(-9999.9999, 9999.9999, ErrorMessage = "Intensity overflows.")]
        public decimal Intensity { get; set; }

        [Range(-9999.9999, 9999.9999, ErrorMessage = "Temperature overflows.")]
        public decimal Temperature { get; set; }

        [Range(-9999.9999, 9999.9999, ErrorMessage = "Humidity overflows.")]
        public decimal Humidity { get; set; }

        [Editable(false)]
        public DateTime Edited { get; set; }

        [Editable(false)]
        public string EditedByUsername { get; set; }

        [Editable(false)]
        public string EditedText => $"{Edited} by {EditedByUsername}";

        [Editable(false)]
        public int ProcessId { get; set; }
    }
}
