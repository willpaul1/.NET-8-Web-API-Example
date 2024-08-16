using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BaseLibrary.Helpers;
using ServerLibrary.Repositories.Contracts;
using Microsoft.AspNetCore.Cors;

namespace ServerTest.Controllers
{

    [Route("api/theaters")]
    [ApiController]
    [AllowAnonymous]
    [EnableCors("AllowWPOnline")]
    public class VenuesController(IVenues theaters) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTheaters([FromQuery] QueryObject query)
        {
            var result = await theaters.GetAllTheaters(query);
            return Ok(result);
        }
    }
}
