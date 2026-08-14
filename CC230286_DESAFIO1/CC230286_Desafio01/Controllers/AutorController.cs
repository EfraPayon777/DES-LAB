using CC230396_Desafio01.BL.Interfaces;
using CC230396_Desafio01.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CC230396_Desafio01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController(IAutorService service) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AutorDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<AutorDto> result = await service.GetAllAutoresAsync();
            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AutorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.GetAutorByIdAsync(id);
            return result != null ? Ok(result) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(AutorDto? dto)
        {
            if (dto == null) return BadRequest();
            var result = await service.InsertAutorAsync(dto);
            return result > 0 ? CreatedAtAction("Post", result) : BadRequest();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, AutorDto? dto)
        {
            if (dto == null) return BadRequest();
            var result = await service.UpdateAutorAsync(dto);
            return result != null ? CreatedAtAction("Post", result) : BadRequest();
        }

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