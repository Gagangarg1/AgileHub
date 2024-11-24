using AgileHub.Api.CustomActionFilters;
using AgileHub.Api.Models.Domain.PokerPlanning;
using AgileHub.Api.Models.DTO.PokerPlanning;
using AgileHub.Api.Repositories.PokerPlanning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgileHub.Api.Controllers.PokerPlanning
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IStoryRepository storyRepository;
        private readonly IMapper mapper;

        public StoriesController(IStoryRepository storyRepository, IMapper mapper)
        {
            this.storyRepository = storyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stories = await storyRepository.GetAllAsync();
            return Ok(mapper.Map<List<StoryDto>>(stories));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var story = await storyRepository.GetByIdAsync(id);
            if (story == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<StoryDto>(story));
        }

        [HttpGet]
        [Route("GetByRoomId{roomId:guid}")]
        public async Task<IActionResult> GetByRoomId([FromRoute] Guid roomId)
        {
            var stories = await storyRepository.GetAllByRoomIdAsync(roomId);
            if (stories == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<StoryDto>>(stories));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreateStoryDto createStoryDto)
        {
            var story = mapper.Map<Story>(createStoryDto);
            story = await storyRepository.CreateAsync(story);
            return CreatedAtAction(nameof(Create), new { id = story.Id }, mapper.Map<StoryDto>(story));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateStoryDto updateStoryDto)
        {
            var story = mapper.Map<Story>(updateStoryDto);
            story = await storyRepository.UpdateAsync(id, story);
            if (story == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<StoryDto>(story));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var story = await storyRepository.DeleteAsync(id);
            if (story == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<StoryDto>(story));
        }
    }
}
