using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BaseLibrary.Helpers;
using ServerLibrary.Repositories.Contracts;
using Microsoft.AspNetCore.Cors;
using BaseLibrary.DTOs;

namespace ServerTest.Controllers
{

    [Route("api/productions")]
    [ApiController]
    [EnableCors("Optional")]
    public class ProductionsController(IEvents productions) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProductionsAsync([FromQuery] QueryObject query)
        {
            var result = await productions.GetAllProductions(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductionByIdAsync(int id)
        {
            var result = await productions.GetProductionById(id);
            return Ok(result);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProductionAsync(CreateProductionDto createProductionDto)
        {
            var result = await productions.CreateProduction(createProductionDto);
            return Ok(result);
        }
        

    }
}
