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
    public class BoardColumnsController : ControllerBase
    {
        private readonly IBoardColumnRepository boardColumnRepository;
        private readonly IMapper mapper;

        public BoardColumnsController(IBoardColumnRepository boardColumnRepository, IMapper mapper)
        {
            this.boardColumnRepository = boardColumnRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var boardColumns = await boardColumnRepository.GetAllAsync();
            return Ok(mapper.Map<List<BoardColumnDto>>(boardColumns));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var boardColumn = await boardColumnRepository.GetByIdAsync(id);
            if (boardColumn == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<BoardColumnDto>(boardColumn));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreateBoardColumnDto createBoardColumnDto)
        {
            var boardColumn = mapper.Map<BoardColumn>(createBoardColumnDto);
            boardColumn = await boardColumnRepository.CreateAsync(boardColumn);
            return CreatedAtAction(nameof(Create), new { id = boardColumn.Id }, mapper.Map<BoardColumnDto>(boardColumn));
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBoardColumnDto updateBoardColumnDto)
        {
            var boardColumn = mapper.Map<BoardColumn>(updateBoardColumnDto);
            boardColumn = await boardColumnRepository.UpdateAsync(id, boardColumn);
            if (boardColumn == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<BoardColumnDto>(boardColumn));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var boardColumn = await boardColumnRepository.DeleteAsync(id);
            if (boardColumn == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<BoardColumnDto>(boardColumn));
        }
    }
}
