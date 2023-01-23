using AutoMapper;
using MagicMansion_Web.Models;
using MagicMansion_Web.Models.Dto;
using MagicMansion_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

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

			return View(list);
		}

        public async Task<IActionResult> CreateMansion()
        {
            return View();
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMansion(MansionCreateDTO model)
        {
			if (ModelState.IsValid)
			{
                var response = await _mansionService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(IndexMansion));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> UpdateMansion(int mansionId)
        {
            if (ModelState.IsValid)
            {
                var response = await _mansionService.GetAsync<APIResponse>(mansionId);
                if (response != null && response.IsSuccess)
                {
                    MansionDTO model = JsonConvert.DeserializeObject<MansionDTO>(Convert.ToString(response.Result));
                    return View(_mapper.Map<MansionUpdateDTO>(model));
                }
                return NotFound();

            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMansion(MansionUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _mansionService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexMansion));
                }
            }

            return View(model);
        }
        public async Task<IActionResult> DeleteMansion(int mansionId)
        {
            if (ModelState.IsValid)
            {
                var response = await _mansionService.GetAsync<APIResponse>(mansionId);
                if (response != null && response.IsSuccess)
                {
                    MansionDTO model = JsonConvert.DeserializeObject<MansionDTO>(Convert.ToString(response.Result));
                    return View(model);
                }
                return NotFound();

            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMansion(MansionDTO model)
        {
            var response = await _mansionService.DeleteAsync<APIResponse>(model.Id);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexMansion));
            }



            return View(model);
        }
    }
}
