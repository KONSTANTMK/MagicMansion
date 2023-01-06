using System.ComponentModel.DataAnnotations;

namespace MagicMansion_MansionAPI.Models.Dto
{
    public class MansionDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
