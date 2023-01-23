using AutoMapper;
using MagicMansion_Web.Models;
using MagicMansion_Web.Models.Dto;
using MagicMansion_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicMansion_Web.Controllers
{
	public class MansionController : Controller
	{
		private readonly IMansionService _mansionService;
		public readonly IMapper _mapper;
		public MansionController(IMansionService mansionService,IMapper mapper)
		{
			_mansionService= mansionService;
			_mapper= mapper;
		}
		public async Task<IActionResult> IndexMansion()
		{
			List<MansionDTO> list = new();


			var response = await _mansionService.GetAllAsync<APIResponse>();
			if(response!=null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<MansionDTO>>(Convert.ToString(response.Result));
			}

			return View();
		}
	}
}
