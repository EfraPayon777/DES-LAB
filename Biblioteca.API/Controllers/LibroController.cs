using Biblioteca.BL.Interfaces;
using Biblioteca.Entites.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController(ILibroService libroService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<LibroDto>>> GetLibros()
        {
            var libros = await libroService.GetLibrosAsync();
            return Ok(libros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibroDto>> GetLibroById(int id)
        {
            var libro = await libroService.GetLibroByIdAsync(id);
            if (libro is null)
                return NotFound();

            return Ok(libro);
        }

        [HttpGet("editorial/{editorialId}")]
        public async Task<ActionResult<List<LibroDto>>> GetLibrosByEditorialId(int editorialId)
        {
            var libros = await libroService.GetLibrosByEditorialIdAsync(editorialId);
            return Ok(libros);
        }

        [HttpPost]
        public async Task<ActionResult<int>> InsertLibro([FromBody] LibroDto libroDto)
        {
            var id = await libroService.InsertLibroAsync(libroDto);
            return CreatedAtAction(nameof(GetLibroById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LibroDto>> UpdateLibro(int id, [FromBody] LibroDto libroDto)
        {
            if (id != libroDto.Id)
                return BadRequest("ID mismatch");

            var result = await libroService.UpdateLibroAsync(libroDto);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteLibro(int id)
        {
            var result = await libroService.DeleteLibroAsync(id);
            if (!result)
                return NotFound();

            return Ok(result);
        }
    }
}
