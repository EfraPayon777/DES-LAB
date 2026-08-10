using Biblioteca.BL.Interfaces;
using Biblioteca.Entites.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditorialController(IEditorialService editorialService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<EditorialDto>>> GetEditoriales()
        {
            var editoriales = await editorialService.GetEditorialesAsync();
            return Ok(editoriales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EditorialDto>> GetEditorialById(int id)
        {
            var editorial = await editorialService.GetEditorialByIdAsync(id);
            if (editorial is null)
                return NotFound();

            return Ok(editorial);
        }

        [HttpPost]
        public async Task<ActionResult<int>> InsertEditorial([FromBody] EditorialDto editorialDto)
        {
            var id = await editorialService.InsertEditorialAsync(editorialDto);
            return CreatedAtAction(nameof(GetEditorialById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EditorialDto>> UpdateEditorial(int id, [FromBody] EditorialDto editorialDto)
        {
            if (id != editorialDto.Id)
                return BadRequest("ID mismatch");

            var result = await editorialService.UpdateEditorialAsync(editorialDto);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteEditorial(int id)
        {
            var result = await editorialService.DeleteEditorialAsync(id);
            if (!result)
                return NotFound();

            return Ok(result);
        }
    }
}
