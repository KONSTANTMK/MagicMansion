﻿using AutoMapper;
using MagicMansion_Web.Models;
using MagicMansion_Web.Models.Dto;
using MagicMansion_Web.Models.VM;
using MagicMansion_Web.Services;
using MagicMansion_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MagicMansion_Web.Controllers
{
    public class MansionNumberController : Controller
    {
        private readonly IMansionNumberService _mansionNumberService;
		private readonly IMansionService _mansionService;
		public readonly IMapper _mapper;
        public MansionNumberController(IMansionNumberService mansionNumberService,IMansionService mansionService,IMapper mapper)
        {
            _mansionNumberService = mansionNumberService;
			_mansionService = mansionService;
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
		public async Task<IActionResult> CreateMansionNumber()
		{
			MansionNumberCreateVM mansionNumberVM = new();
			var response = await _mansionService.GetAllAsync<APIResponse>();
			if (response != null && response.IsSuccess)
			{
				mansionNumberVM.MansionList = JsonConvert.DeserializeObject<List<MansionDTO>>
					(Convert.ToString(response.Result)).Select(i => new SelectListItem
					{
						Text = i.Name,
						Value = i.Id.ToString()
					});
			}
			return View(mansionNumberVM);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateMansionNumber(MansionNumberCreateVM model)
		{
			if (ModelState.IsValid)
			{
				var response = await _mansionNumberService.CreateAsync<APIResponse>(model.MansionNumber);
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(IndexMansionNumber));
				}
			}

			return View(model);
		}

		//public async Task<IActionResult> UpdateMansionNumber(int mansionId)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		var response = await _mansionNumberService.GetAsync<APIResponse>(mansionId);
		//		if (response != null && response.IsSuccess)
		//		{
		//			MansionNumberDTO model = JsonConvert.DeserializeObject<MansionNumberDTO>(Convert.ToString(response.Result));
		//			return View(_mapper.Map<MansionNumberUpdateDTO>(model));
		//		}
		//		return NotFound();

		//	}
		//	return View();
		//}
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> UpdateMansionNumber(MansionNumberUpdateDTO model)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		var response = await _mansionNumberService.UpdateAsync<APIResponse>(model);
		//		if (response != null && response.IsSuccess)
		//		{
		//			return RedirectToAction(nameof(IndexMansionNumber));
		//		}
		//	}

		//	return View(model);
		//}
		//public async Task<IActionResult> DeleteMansionNumber(int mansionId)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		var response = await _mansionNumberService.GetAsync<APIResponse>(mansionId);
		//		if (response != null && response.IsSuccess)
		//		{
		//			MansionNumberDTO model = JsonConvert.DeserializeObject<MansionNumberDTO>(Convert.ToString(response.Result));
		//			return View(model);
		//		}
		//		return NotFound();

		//	}
		//	return View();
		//}
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> DeleteMansionNumber(MansionNumberDTO model)
		//{
		//	var response = await _mansionNumberService.DeleteAsync<APIResponse>(model.Id);
		//	if (response != null && response.IsSuccess)
		//	{
		//		return RedirectToAction(nameof(IndexMansionNumber));
		//	}



		//	return View(model);
		//}
	}
}