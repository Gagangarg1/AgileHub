using AgileHub.Api.CustomActionFilters;
using AgileHub.Api.Models.Domain.SprintRetro;
using AgileHub.Api.Models.DTO.SprintRetro;
using AgileHub.Api.Repositories.SprintRetro;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgileHub.Api.Controllers.SprintRetro
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository noteRepository;
        private readonly IMapper mapper;

        public NotesController(INoteRepository noteRepository, IMapper mapper)
        {
            this.noteRepository = noteRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notes = await noteRepository.GetAllAsync();
            return Ok(mapper.Map<List<NoteDto>>(notes));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var note = await noteRepository.GetByIdAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<NoteDto>(note));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreateNoteDto createNoteDto)
        {
            var note = mapper.Map<Note>(createNoteDto);
            note = await noteRepository.CreateAsync(note);
            return CreatedAtAction(nameof(Create), new { id = note.Id }, mapper.Map<NoteDto>(note));
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateNoteDto updateNoteDto)
        {
            var note = mapper.Map<Note>(updateNoteDto);
            note = await noteRepository.UpdateAsync(id, note);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<NoteDto>(note));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var note = await noteRepository.DeleteAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<NoteDto>(note));
        }
    }
}
