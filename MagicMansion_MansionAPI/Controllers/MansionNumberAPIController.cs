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
    [Route("api/MansionNumberAPI")]
    [ApiController]
    public class MansionNumberAPIController : ControllerBase
    {
        private readonly IMansionNumberRepository _dbMansionNumber;
        private readonly IMapper _mapper;
		private readonly APIResponse _response;
		public MansionNumberAPIController(IMansionNumberRepository dbMansionNumber, IMapper mapper)
        {
			_dbMansionNumber = dbMansionNumber;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetMansionNumbers()
        {
            try
            {
                IEnumerable<MansionNumber> mansionNumberList = await _dbMansionNumber.GetAllAsync();
                _response.Result = _mapper.Map<List<MansionNumberDTO>>(mansionNumberList);
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

        [HttpGet("{id:int}", Name = "GetMansionNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetMansionNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var mansionNumber = await _dbMansionNumber.GetAsync(u => u.MansionNo == id);

                if (mansionNumber == null)
                {
					_response.StatusCode = HttpStatusCode.NotFound;
					return NotFound(_response);
                }
			    _response.Result = _mapper.Map<MansionNumberDTO>(mansionNumber);
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
        public async Task<ActionResult<APIResponse>> CreateMansionNumber([FromBody] MansionNumberCreateDTO createDTO)
        {
            try
            { 
            if (await _dbMansionNumber.GetAsync(u => u.MansionNo == createDTO.MansionNo) != null)
            {
                ModelState.AddModelError("Custom error", "Mansion number already exists");
                return BadRequest(ModelState);
            }
            if (createDTO == null)
            {
                return BadRequest();
            }

			MansionNumber model = _mapper.Map<MansionNumber>(createDTO);
            await _dbMansionNumber.CreateAsync(model);
			_response.Result = _mapper.Map<MansionNumberDTO>(model);
			_response.StatusCode = HttpStatusCode.Created;
			return CreatedAtRoute("GetMansion", new { id = model.MansionNo }, _response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };

			}
			return _response;
		}
        [HttpDelete("{id:int}", Name = "DeleteMansionNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteMansionNumber(int id)
        {
            try
            { 
            if (id == 0) return BadRequest();
            var mansionNumber = await _dbMansionNumber.GetAsync(u => u.MansionNo == id);
            if (mansionNumber == null) return NotFound();
			await _dbMansionNumber.RemoveAsync(mansionNumber);
			_response.Result = _mapper.Map<MansionNumberDTO>(mansionNumber);
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
        [HttpPut("{id:int}", Name = "UpdateMansionNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateMansionNumber(int id,[FromBody] MansionNumberUpdateDTO updateDTO)
        {
            try
            {
            if(updateDTO == null || id != updateDTO.MansionNo) return BadRequest();

			MansionNumber model = _mapper.Map<MansionNumber>(updateDTO);
			await _dbMansionNumber.UpdateAsync(model);
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
       
    }
}
