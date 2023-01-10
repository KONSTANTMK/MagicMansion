using AutoMapper;
using MagicMansion_MansionAPI.Data;
using MagicMansion_MansionAPI.Models;
using MagicMansion_MansionAPI.Models.Dto;
using MagicMansion_MansionAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicMansion_MansionAPI.Controllers
{
    [Route("api/MansionAPI")]
    [ApiController]
    public class MansionAPIController : ControllerBase
    {
        private readonly IMansionRepository _dbMansion;
        private readonly IMapper _mapper;
        public MansionAPIController(IMansionRepository dbMansion,IMapper mapper)
        {
            _dbMansion = dbMansion;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MansionUpdateDTO>>> GetMansions()
        {
            IEnumerable<Mansion> mansionList = await _dbMansion.GetAllAsync();
            return Ok(_mapper.Map<List<MansionDTO>>(mansionList));
        }

        [HttpGet("{id:int}", Name = "GetMansion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MansionDTO>> GetMansion(int id)
        {
            if (id == 0)
            {

                return BadRequest();
            }
            var mansion = await _dbMansion.GetAsync(u => u.Id == id);

            if (mansion == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MansionDTO>(mansion));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MansionCreateDTO>> CreateMasion([FromBody] MansionCreateDTO createDTO)
        {

            if (await _dbMansion.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Custom error", "Mansion already exists");
                return BadRequest(ModelState);
            }
            if (createDTO == null)
            {
                return BadRequest();
            }

            Mansion model = _mapper.Map<Mansion>(createDTO);
            await _dbMansion.CreateAsync(model);
            await _dbMansion.SaveAsync();
            return CreatedAtRoute("GetMansion", new { id = model.Id }, model);
        }
        [HttpDelete("{id:int}", Name = "DeleteMansion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMansion(int id)
        {
            if (id == 0) return BadRequest();
            var mansion = await _dbMansion.GetAsync(u => u.Id == id);
            if (mansion == null) return NotFound();
			await _dbMansion.RemoveAsync(mansion);
            return NoContent();
        }
        [HttpPut("{id:int}", Name = "UpdateMansion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateMansion(int id,[FromBody] MansionUpdateDTO updateDTO)
        {
            if(updateDTO == null || id != updateDTO.Id) return BadRequest();

			Mansion model = _mapper.Map<Mansion>(updateDTO);

			await _dbMansion.UpdateAsync(model);
            return NoContent();
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
