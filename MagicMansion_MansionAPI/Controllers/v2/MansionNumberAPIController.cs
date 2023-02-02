using AutoMapper;
using MagicMansion_MansionAPI.Data;
using MagicMansion_MansionAPI.Models;
using MagicMansion_MansionAPI.Models.Dto;
using MagicMansion_MansionAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;

namespace MagicMansion_MansionAPI.Controllers.v2
{
    [Route("api/v{version:apiVersion}/MansionNumberAPI")]
    [ApiController]
    [ApiVersion("2.0")]
   
    public class MansionNumberAPIController : ControllerBase
    {
        private readonly IMansionNumberRepository _dbMansionNumber;
        private readonly IMansionRepository _dbMansion;
        private readonly IMapper _mapper;
		private readonly APIResponse _response;
		public MansionNumberAPIController(IMansionNumberRepository dbMansionNumber,IMansionRepository dbMansion, IMapper mapper)
        {
			_dbMansionNumber = dbMansionNumber;
            _dbMansion = dbMansion;
            _mapper = mapper;
            this._response = new();
        }
        //[MapToApiVersion("2.0")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
