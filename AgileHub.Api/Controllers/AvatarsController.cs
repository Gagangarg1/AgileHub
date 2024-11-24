using AgileHub.Api.CustomActionFilters;
using AgileHub.Api.Models.Domain;
using AgileHub.Api.Models.DTO;
using AgileHub.Api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgileHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvatarsController : ControllerBase
    {
        private readonly IAvatarRepository avatarRepository;
        private readonly IMapper mapper;

        public AvatarsController(IAvatarRepository avatarRepository, IMapper mapper)
        {
            this.avatarRepository = avatarRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var avatars = await avatarRepository.GetAllAsync();
            return Ok(mapper.Map<List<AvatarDto>>(avatars));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var avatar = await avatarRepository.GetByIdAsync(id);
            if (avatar == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<AvatarDto>(avatar));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreateAvatarDto createAvatarDto)
        {
            var avatar = mapper.Map<Avatar>(createAvatarDto);
            avatar = await avatarRepository.CreateAsync(avatar);
            return CreatedAtAction(nameof(Create), new { id = avatar.Id }, mapper.Map<AvatarDto>(avatar));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAvatarDto updateAvatarDto)
        {
            var avatar = mapper.Map<Avatar>(updateAvatarDto);
            avatar = await avatarRepository.UpdateAsync(id, avatar);
            if (avatar == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<AvatarDto>(avatar));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var avatar = await avatarRepository.DeleteAsync(id);
            if (avatar == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<AvatarDto>(avatar));
        }
    }
}
