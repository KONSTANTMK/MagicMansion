using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicMansion_MansionAPI.Models
{
	public class MansionNumber
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int MansionNo { get; set; }
		[ForeignKey("Villa")]
		public int MansionID { get; set; }
		public Mansion Mansion { get; set; }
		public string SpecialDetails { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
	}
}
