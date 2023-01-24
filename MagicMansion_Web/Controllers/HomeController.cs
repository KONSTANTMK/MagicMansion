using AutoMapper;
using MagicMansion_Web.Models;
using MagicMansion_Web.Models.Dto;
using MagicMansion_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MagicMansion_Web.Controllers
{
	public class HomeController : Controller
	{
        private readonly IMansionService _mansionService;
        public readonly IMapper _mapper;
        public HomeController(IMansionService mansionService, IMapper mapper)
        {
            _mansionService = mansionService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<MansionDTO> list = new();


            var response = await _mansionService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<MansionDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
	}
}