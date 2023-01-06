using MagicMansion_MansionAPI.Data;
using MagicMansion_MansionAPI.Models;
using MagicMansion_MansionAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicMansion_MansionAPI.Controllers
{
    [Route("api/MansionAPI")]
    //[ApiController]
    public class MansionAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<MansionDTO>> GetMansions()
        {
            return Ok(MansionStore.masionList);
        }

        [HttpGet("{id:int}",Name="GetMansion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MansionDTO> GetMansion(int id)
        {
            if(id== 0)
            {
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
        public ActionResult<MansionDTO> CreateMasion([FromBody]MansionDTO mansionDTO)
        {
            if(ModelState.IsValid)
            {

            }
            if(mansionDTO == null)
            {
                return BadRequest();
            }
            if (mansionDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            mansionDTO.Id = MansionStore.masionList.OrderByDescending(u=>u.Id).FirstOrDefault().Id+1;
            MansionStore.masionList.Add(mansionDTO);
            return CreatedAtRoute("GetMansion",new {id = mansionDTO.Id},mansionDTO);
        }
    }
}
