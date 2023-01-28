using AutoMapper;
using MagicMansion_MansionAPI.Data;
using MagicMansion_MansionAPI.Models;
using MagicMansion_MansionAPI.Models.Dto;
using MagicMansion_MansionAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MagicMansion_MansionAPI.Controllers
{
    [Route("api/MansionAPI")]
    [ApiController]
    public class MansionAPIController : ControllerBase
    {
        private readonly IMansionRepository _dbMansion;
        private readonly IMapper _mapper;
		private readonly APIResponse _response;
		public MansionAPIController(IMansionRepository dbMansion,IMapper mapper)
        {
            _dbMansion = dbMansion;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetMansions()
        {
            try
            {
                IEnumerable<Mansion> mansionList = await _dbMansion.GetAllAsync();
                _response.Result = _mapper.Map<List<MansionDTO>>(mansionList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess= false;
                _response.ErrorMessages= new List<string>() {ex.ToString()};
            }
            return _response;
		}

        [HttpGet("{id:int}", Name = "GetMansion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetMansion(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var mansion = await _dbMansion.GetAsync(u => u.Id == id);

                if (mansion == null)
                {
					_response.StatusCode = HttpStatusCode.NotFound;
					return NotFound(_response);
                }
			    _response.Result = _mapper.Map<MansionDTO>(mansion);
			    _response.StatusCode = HttpStatusCode.OK;
			    return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;


		}
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateMansion([FromBody] MansionCreateDTO createDTO)
        {
            try
            { 
            if (await _dbMansion.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("ErrorMessages", "Mansion already exists");
                return BadRequest(ModelState);
            }
            if (createDTO == null)
            {
                return BadRequest();
            }

            Mansion model = _mapper.Map<Mansion>(createDTO);
            await _dbMansion.CreateAsync(model);
			_response.Result = _mapper.Map<MansionDTO>(model);
			_response.StatusCode = HttpStatusCode.Created;
			return CreatedAtRoute("GetMansion", new { id = model.Id }, _response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };

			}
			return _response;
		}
        [HttpDelete("{id:int}", Name = "DeleteMansion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteMansion(int id)
        {
            try
            { 
            if (id == 0) return BadRequest();
            var mansion = await _dbMansion.GetAsync(u => u.Id == id);
            if (mansion == null) return NotFound();
			await _dbMansion.RemoveAsync(mansion);
			_response.Result = _mapper.Map<MansionDTO>(mansion);
			_response.StatusCode = HttpStatusCode.NoContent;
			return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };

			}
			return _response;
		}
        [HttpPut("{id:int}", Name = "UpdateMansion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateMansion(int id,[FromBody] MansionUpdateDTO updateDTO)
        {
            try
            {
            if(updateDTO == null || id != updateDTO.Id) return BadRequest();

			Mansion model = _mapper.Map<Mansion>(updateDTO);
			await _dbMansion.UpdateAsync(model);
			_response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess= true;
			return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };

			}
			return _response;
		}
        [HttpPatch("{id:int}", Name = "UpdatePartialMansion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialMansion(int id, JsonPatchDocument<MansionUpdateDTO> patchDTO)
        {
            if(patchDTO == null || id==0) return BadRequest();

            var mansion = await _dbMansion.GetAsync(u=>u.Id==id,tracked:false);

			MansionUpdateDTO mansionDTO = _mapper.Map<MansionUpdateDTO>(mansion);

            if (mansion == null) return BadRequest();
            patchDTO.ApplyTo(mansionDTO,ModelState);

			Mansion model = _mapper.Map<Mansion>(mansionDTO);
            await _dbMansion.UpdateAsync(model);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return NoContent();
        }
    }
}
