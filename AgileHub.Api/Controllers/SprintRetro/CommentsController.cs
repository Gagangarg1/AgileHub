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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;

        public CommentsController(ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await commentRepository.GetAllAsync();
            return Ok(mapper.Map<List<CommentDto>>(comments));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var comment = await commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CommentDto>(comment));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreateCommentDto createCommentDto)
        {
            var comment = mapper.Map<Comment>(createCommentDto);
            comment = await commentRepository.CreateAsync(comment);
            return CreatedAtAction(nameof(Create), new { id = comment.Id }, mapper.Map<CommentDto>(comment));
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCommentDto updateCommentDto)
        {
            var comment = mapper.Map<Comment>(updateCommentDto);
            comment = await commentRepository.UpdateAsync(id, comment);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CommentDto>(comment));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var comment = await commentRepository.DeleteAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CommentDto>(comment));
        }
    }
}
