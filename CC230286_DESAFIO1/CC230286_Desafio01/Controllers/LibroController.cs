using CC230396_Desafio01.BL.Interfaces;
using CC230396_Desafio01.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CC230396_Desafio01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController(ILibroService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await service.GetAllLibrosAsync();
            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.GetLibroByIdAsync(id);
            return result != null ? Ok(result) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(LibroDto? dto)
        {
            if (dto == null) return BadRequest();
            var result = await service.InsertLibroAsync(dto);
            return result > 0 ? CreatedAtAction(nameof(Get), new { id = result }, result) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, LibroDto? dto)
        {
            if (dto == null) return BadRequest();
            var result = await service.UpdateLibroAsync(dto);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.DeleteLibroAsync(id);
            return result ? Ok(result) : BadRequest();
        }
    }
}