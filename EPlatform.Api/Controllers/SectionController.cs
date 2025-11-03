using Microsoft.AspNetCore.Mvc;
using EPlatform.Application.Interfaces;
using EPlatform.Application.Dtos;

namespace EPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sections = await _sectionService.GetAll();
            return Ok(sections);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SectionCreateDto dto)
        {
            if (dto == null)
                return BadRequest("El objeto enviado es nulo.");

            var createdSection = await _sectionService.Create(dto);

            return CreatedAtAction(nameof(GetAll), new { id = createdSection?.Id }, createdSection);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] SectionUpdateDto dto)
        {
            if (dto == null)
                return BadRequest("El objeto enviado es nulo.");

            var updated = await _sectionService.Update(id, dto);
            if (updated == null)
                return NotFound($"No se encontró la sección con ID {id}.");

            return Ok(updated);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _sectionService.Delete(id);
            if (!deleted)
                return NotFound($"No se encontró la sección con ID {id}.");

            return NoContent();
        }
    }
}