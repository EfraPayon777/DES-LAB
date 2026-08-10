using Biblioteca.BL.Interfaces;
using Biblioteca.Entites.Dtos;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.BL.Interfaces; 
using Biblioteca.Entites.Dtos; 
using Microsoft.AspNetCore.Mvc; 
 
namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController(IAutorService service) : ControllerBase
    {
        // GET: api/<AutorController> 
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IEnumerable<AutorDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<AutorDto> result = await service.GetAllAutoresAsync();
            return result.Any() ? Ok(result) : NoContent();
        }
 
        // GET api/<AutorController>/5 
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AutorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.GetAutorByIdAsync(id);
            return result != null ? Ok(result) : NoContent();
        }

        // POST api/<AutorController> 
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AutorDto? dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var result = await service.InsertAutorAsync(dto);
            return result > 0 ? CreatedAtAction("Post", result) : BadRequest();
        }

        // PUT api/<AutorController>/5 
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] AutorDto? dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var result = await service.UpdateAutorAsync(dto);
            return result != null ? CreatedAtAction("Post", result) : BadRequest();
        }

        // DELETE api/<AutorController>/5 
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.DeleteAutorAsync(id);
            return result ? Ok(result) : BadRequest();
        }
    }
}