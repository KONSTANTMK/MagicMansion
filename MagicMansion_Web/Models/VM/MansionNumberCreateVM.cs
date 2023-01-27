using MagicMansion_MansionAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicMansion_Web.Models.VM
{
	public class MansionNumberCreateVM
	{
		public MansionNumberCreateVM()
		{
			MansionNumber = new MansionCreateDTO();
		}
		public MansionCreateDTO MansionNumber { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> MansionList { get; set; }
	}
}
