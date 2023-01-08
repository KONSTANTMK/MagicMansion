using MagicMansion_MansionAPI.Data;
//using MagicMansion_MansionAPI.Logging;
using MagicMansion_MansionAPI.Models;
using MagicMansion_MansionAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicMansion_MansionAPI.Controllers
{
    [Route("api/MansionAPI")]
    [ApiController]
    public class MansionAPIController : ControllerBase
    {

        //Main logger//private readonly ILogger<MansionAPIController> _logger;
        //public MansionAPIController(ILogger<MansionAPIController> logger)
        //{
        //    //Main logger//_logger = logger;
        //}

        //Custom logger//private readonly ILogging _logger;
        //public MansionAPIController(ILogging logger)
        //{
        //    _logger= logger;
        //}

        private readonly ApplicationDbContext _db;
        public MansionAPIController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<MansionDTO>> GetMansions()
        {
            //Main logger//_logger.LogInformation("Geting all mansions");
            //Custom logger//_logger.Log("Geting all mansions","");
            return Ok(_db.Mansions.ToList());
        }

        [HttpGet("{id:int}", Name = "GetMansion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MansionDTO> GetMansion(int id)
        {
            if (id == 0)
            {
                //Main logger//_logger.LogError("Get mansion error with id " + id);
                //Custom logger//_logger.Log("Get mansion error with id " + id,"error");
                return BadRequest();
            }
            var Mansion = _db.Mansions.FirstOrDefault(u => u.Id == id);

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
            if (_db.Mansions.FirstOrDefault(u => u.Name.ToLower() == mansionDTO.Name.ToLower()) != null)
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
 
            Mansion model = new()
            {
                Amenity = mansionDTO.Amenity,
                Details= mansionDTO.Details,
                Id = mansionDTO.Id,
                ImageUrl= mansionDTO.ImageUrl,
                Name = mansionDTO.Name,
                Occupancy= mansionDTO.Occupancy,
                Rate= mansionDTO.Rate,
                Sqft= mansionDTO.Sqft,

            };
            _db.Mansions.Add(model);
            _db.SaveChanges();
            return CreatedAtRoute("GetMansion", new { id = mansionDTO.Id }, mansionDTO);
        }
        [HttpDelete("{id:int}", Name = "DeleteMansion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteMansion(int id)
        {
            if (id == 0) return BadRequest();
            var mansion = _db.Mansions.FirstOrDefault(u => u.Id == id);
            if (mansion == null) return NotFound();
            _db.Mansions.Remove(mansion);
            _db.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id:int}", Name = "UpdateMansion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateMansion(int id,[FromBody] MansionDTO mansionDTO)
        {
            if(mansionDTO == null || id != mansionDTO.Id) return BadRequest();
            //var mansion = _db.Mansions.FirstOrDefault(u=>u.Id==id);
            //mansion.Name = mansionDTO.Name;
            //mansion.Sqft= mansionDTO.Sqft;
            //mansion.Occupancy = mansionDTO.Occupancy;

            Mansion model = new()
            {
                Amenity = mansionDTO.Amenity,
                Details = mansionDTO.Details,
                Id = mansionDTO.Id,
                ImageUrl = mansionDTO.ImageUrl,
                Name = mansionDTO.Name,
                Occupancy = mansionDTO.Occupancy,
                Rate = mansionDTO.Rate,
                Sqft = mansionDTO.Sqft,

            };
            _db.Mansions.Update(model);
            _db.SaveChanges();
            return NoContent();
        }
        [HttpPatch("{id:int}", Name = "UpdatePartialMansion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialMansion(int id, JsonPatchDocument<MansionDTO> patchDTO)
        {
            if(patchDTO == null || id==0) return BadRequest();

            var mansion = _db.Mansions.AsNoTracking().FirstOrDefault(u=>u.Id==id);

            MansionDTO mansionDTO = new()
            {
                Amenity = mansion.Amenity,
                Details = mansion.Details,
                Id = mansion.Id,
                ImageUrl = mansion.ImageUrl,
                Name = mansion.Name,
                Occupancy = mansion.Occupancy,
                Rate = mansion.Rate,
                Sqft = mansion.Sqft,

            };

            if (mansion == null) return BadRequest();
            patchDTO.ApplyTo(mansionDTO,ModelState);

            Mansion model = new()
            {
                Amenity = mansionDTO.Amenity,
                Details = mansionDTO.Details,
                Id = mansionDTO.Id,
                ImageUrl = mansionDTO.ImageUrl,
                Name = mansionDTO.Name,
                Occupancy = mansionDTO.Occupancy,
                Rate = mansionDTO.Rate,
                Sqft = mansionDTO.Sqft,

            };
            _db.Mansions.Update(model);
            _db.SaveChanges();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return NoContent();
        }
    }
}
