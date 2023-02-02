using AutoMapper;
using MagicMansion_Utility;
using MagicMansion_Web.Models;
using MagicMansion_Web.Models.Dto;
using MagicMansion_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
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


			var response = await _mansionService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
			if(response!=null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<MansionDTO>>(Convert.ToString(response.Result));
			}

			return View(list);
		}
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateMansion()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMansion(MansionCreateDTO model)
        {
			if (ModelState.IsValid)
			{
                var response = await _mansionService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
				{
                    TempData["success"] = "Villa created successfully";
                    return RedirectToAction(nameof(IndexMansion));
                }
            }
            TempData["error"] = "Error encountered";
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateMansion(int mansionId)
        {
            if (ModelState.IsValid)
            {
                var response = await _mansionService.GetAsync<APIResponse>(mansionId, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    MansionDTO model = JsonConvert.DeserializeObject<MansionDTO>(Convert.ToString(response.Result));
                    return View(_mapper.Map<MansionUpdateDTO>(model));
                }
                return NotFound();

            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMansion(MansionUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Villa updated successfully";
                var response = await _mansionService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    
                    return RedirectToAction(nameof(IndexMansion));
                }
            }
            TempData["error"] = "Error encountered";
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMansion(int mansionId)
        {
            if (ModelState.IsValid)
            {
                var response = await _mansionService.GetAsync<APIResponse>(mansionId, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    MansionDTO model = JsonConvert.DeserializeObject<MansionDTO>(Convert.ToString(response.Result));
                    return View(model);
                }
                return NotFound();

            }
            return View(mansionId);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMansion(MansionDTO model)
        {
            var response = await _mansionService.DeleteAsync<APIResponse>(model.Id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Villa deleted successfully";
                return RedirectToAction(nameof(IndexMansion));
            }
            TempData["error"] = "Error encountered";
            return View(model);
        }
    }
}
