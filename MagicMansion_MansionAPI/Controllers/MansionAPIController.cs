using MagicMansion_MansionAPI.Data;
using MagicMansion_MansionAPI.Models;
using MagicMansion_MansionAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicMansion_MansionAPI.Controllers
{
    [Route("api/MansionAPI")]
    [ApiController]
    public class MansionAPIController : ControllerBase
    {
        private readonly ILogger<MansionAPIController> _logger;

        public MansionAPIController(ILogger<MansionAPIController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<MansionDTO>> GetMansions()
        {
            _logger.LogInformation("Geting all mansions");
            return Ok(MansionStore.masionList);
        }

        [HttpGet("{id:int}", Name = "GetMansion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MansionDTO> GetMansion(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Get mansion error with id " + id);
                return BadRequest();
            }
            var Mansion = MansionStore.masionList.FirstOrDefault(u => u.Id == id);

            if (Mansion == null)
            {
                return NotFound();
            }
            return Ok(Mansion);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MansionDTO> CreateMasion([FromBody] MansionDTO mansionDTO)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (MansionStore.masionList.FirstOrDefault(u => u.Name.ToLower() == mansionDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Custom error", "Mansion already exists");
                return BadRequest(ModelState);
            }
            if (mansionDTO == null)
            {
                return BadRequest();
            }
            if (mansionDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            mansionDTO.Id = MansionStore.masionList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            MansionStore.masionList.Add(mansionDTO);
            return CreatedAtRoute("GetMansion", new { id = mansionDTO.Id }, mansionDTO);
        }
        [HttpDelete("{id:int}", Name = "DeleteMansion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteMansion(int id)
        {
            if (id == 0) return BadRequest();
            var mansion = MansionStore.masionList.FirstOrDefault(u => u.Id == id);
            if (mansion == null) return NotFound();
            MansionStore.masionList.Remove(mansion);
            return NoContent();
        }
        [HttpPut("{id:int}", Name = "UpdateMansion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateMansion(int id,[FromBody] MansionDTO mansionDTO)
        {
            if(mansionDTO == null || id != mansionDTO.Id) return BadRequest();
            var mansion = MansionStore.masionList.FirstOrDefault(u=>u.Id==id);
            mansion.Name = mansionDTO.Name;
            mansion.Sqft= mansionDTO.Sqft;
            mansion.Occupancy = mansionDTO.Occupancy;
            return NoContent();
        }
        [HttpPatch("{id:int}", Name = "UpdatePartialMansion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialMansion(int id, JsonPatchDocument<MansionDTO> patchDTO)
        {
            if(patchDTO == null || id==0) return BadRequest();
            var mansion = MansionStore.masionList.FirstOrDefault(u=>u.Id==id);
            if(mansion == null) return BadRequest();
            patchDTO.ApplyTo(mansion,ModelState);
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return NoContent();
        }
    }
}
