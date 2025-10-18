using DPA.Practica0123200299.CORE.Core.Entities;
using DPA.Practica0123200299.CORE.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Practica0123200299.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarreraController : ControllerBase
    {
        private readonly ICarreraService _carreraService;
        public CarreraController(ICarreraService carreraService)
        {
            _carreraService = carreraService;
        }
        // Action methods for handling HTTP requests will go here

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _carreraService.GetAllCarrerasAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var carrear = await _carreraService.GetCarreraByIdAsync(id);
            if (carrear == null)
            {
                return NotFound();
            }
            return Ok(carrear);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarrera([FromBody] Carrera carrera)
        {
            if (carrera == null)
            {
                return BadRequest();
            }
            var createdCategoryId = await _carreraService.AddCarreraAsync(carrera);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategoryId }, carrera);
        }


        
    }
}
