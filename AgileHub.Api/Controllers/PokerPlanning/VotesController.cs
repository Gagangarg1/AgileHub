using AgileHub.Api.Models.Domain.PokerPlanning;
using AgileHub.Api.Models.DTO.PokerPlanning;
using AgileHub.Api.Repositories.PokerPlanning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgileHub.Api.Controllers.PokerPlanning
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly IVoteRepository voteRepository;
        private readonly IMapper mapper;

        public VotesController(IVoteRepository voteRepository, IMapper mapper)
        {
            this.voteRepository = voteRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var votes = await voteRepository.GetAllAsync();
            return Ok(mapper.Map<List<VoteDto>>(votes));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var vote = await voteRepository.GetByIdAsync(id);
            if (vote == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<VoteDto>(vote));
        }

        [HttpGet]
        [Route("GetByStoryId{storyId:guid}")]
        public async Task<IActionResult> GetByStoryId([FromRoute] Guid storyId)
        {
            var votes = await voteRepository.GetByStoryIdAsync(storyId);
            if (votes == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<VoteDto>>(votes));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVoteDto createVoteDto)
        {
            var vote = mapper.Map<Vote>(createVoteDto);
            vote = await voteRepository.CreateAsync(vote);
            return CreatedAtAction(nameof(Create), new { id = vote.Id }, mapper.Map<VoteDto>(vote));
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateVoteDto updateVoteDto)
        {
            var vote = mapper.Map<Vote>(updateVoteDto);
            vote = await voteRepository.UpdateAsync(id, vote);
            if (vote == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<VoteDto>(vote));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var vote = await voteRepository.DeleteAsync(id);
            if (vote == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<VoteDto>(vote));
        }
    }
}
