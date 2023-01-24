using AutoMapper;
using MagicMansion_Web.Models;
using MagicMansion_Web.Models.Dto;
using MagicMansion_Web.Services;
using MagicMansion_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicMansion_Web.Controllers
{
    public class MansionNumberController : Controller
    {
        private readonly IMansionNumberService _mansionNumberService;
        public readonly IMapper _mapper;
        public MansionNumberController(IMansionNumberService mansionNumberService, IMapper mapper)
        {
            _mansionNumberService = mansionNumberService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexMansionNumber()
        {
            List<MansionNumberDTO> list = new();


            var response = await _mansionNumberService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<MansionNumberDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
    }
}