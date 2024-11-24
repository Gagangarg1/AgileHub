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
    public class RetroBoardsController : ControllerBase
    {
        private readonly IRetroBoardRepository retroBoardRepository;
        private readonly IMapper mapper;

        public RetroBoardsController(IRetroBoardRepository retroBoardRepository, IMapper mapper)
        {
            this.retroBoardRepository = retroBoardRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var retroBoards = await retroBoardRepository.GetAllAsync();
            return Ok(mapper.Map<List<RetroBoardDto>>(retroBoards));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var retroBoard = await retroBoardRepository.GetByIdAsync(id);
            if (retroBoard == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RetroBoardDto>(retroBoard));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreateRetroBoardDto createRetroBoardDto)
        {
            var retroBoard = mapper.Map<RetroBoard>(createRetroBoardDto);
            retroBoard = await retroBoardRepository.CreateAsync(retroBoard);
            return CreatedAtAction(nameof(Create), new { id = retroBoard.Id }, mapper.Map<RetroBoardDto>(retroBoard));
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRetroBoardDto updateRetroBoardDto)
        {
            var retroBoard = mapper.Map<RetroBoard>(updateRetroBoardDto);
            retroBoard = await retroBoardRepository.UpdateAsync(id, retroBoard);
            if (retroBoard == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RetroBoardDto>(retroBoard));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var retroBoard = await retroBoardRepository.DeleteAsync(id);
            if (retroBoard == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RetroBoardDto>(retroBoard));
        }
    }
}
