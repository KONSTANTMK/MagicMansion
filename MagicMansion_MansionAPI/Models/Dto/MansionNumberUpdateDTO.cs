﻿using System.ComponentModel.DataAnnotations;

namespace MagicMansion_MansionAPI.Models.Dto
{
    public class MansionNumberUpdateDTO
    {
        [Required]
        public int MansionNo { get; set; }
        public string SpecialDetails { get; set; }
    
    }
}
