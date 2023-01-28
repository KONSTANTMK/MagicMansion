﻿using MagicMansion_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicMansion_Web.Models.VM
{
	public class MansionNumberCreateVM
	{
		public MansionNumberCreateVM()
		{
			MansionNumber = new MansionNumberCreateDTO();
		}
		public MansionNumberCreateDTO MansionNumber { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> MansionList { get; set; }
	}
}
