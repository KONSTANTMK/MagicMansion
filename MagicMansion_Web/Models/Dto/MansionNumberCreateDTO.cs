using System.ComponentModel.DataAnnotations;

namespace MagicMansion_Web.Models.Dto
{
    public class MansionNumberCreateDTO
    {
        [Required]
        public int MansionNo { get; set; }
        [Required]
        public int MansionID { get; set; }
        public string SpecialDetails { get; set; }
    
    }
}
