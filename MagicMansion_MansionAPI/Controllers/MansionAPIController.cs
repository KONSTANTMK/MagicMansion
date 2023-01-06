using MagicMansion_MansionAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagicMansion_MansionAPI.Controllers
{
    [Route("api/MansionAPI")]
    [ApiController]
    public class MansionAPIController : ControllerBase
    {
        public IEnumerable<Mansion> GetMansions()
        {
            return new List<Mansion>
            {
                new Mansion{Id=1,Name="Pool View"},
                new Mansion{Id=2,Name="Beach View"}
            };
        }
    }
}
