using CC230396_Desafio01.BL.Interfaces;
using CC230396_Desafio01.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CC230396_Desafio01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController(ICategoriaService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await service.GetAllCategoriasAsync();
            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.GetCategoriaByIdAsync(id);
            return result != null ? Ok(result) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoriaDto? dto)
        {
            if (dto == null) return BadRequest();
            var result = await service.InsertCategoriaAsync(dto);
            return result > 0 ? CreatedAtAction(nameof(Get), new { id = result }, result) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CategoriaDto? dto)
        {
            if (dto == null) return BadRequest();
            var result = await service.UpdateCategoriaAsync(dto);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.DeleteCategoriaAsync(id);
            return result ? Ok(result) : BadRequest();
        }
    }
}