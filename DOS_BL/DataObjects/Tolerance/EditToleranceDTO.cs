using DOS_BL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DOS_BL.DataObjects
{
    public class EditToleranceDTO : CreateToleranceDTO, IEditDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
