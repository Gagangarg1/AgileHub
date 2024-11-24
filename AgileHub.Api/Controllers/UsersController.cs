using AgileHub.Api.CustomActionFilters;
using AgileHub.Api.Models.Domain;
using AgileHub.Api.Models.Domain.PokerPlanning;
using AgileHub.Api.Models.DTO;
using AgileHub.Api.Models.DTO.PokerPlanning;
using AgileHub.Api.Repositories;
using AgileHub.Api.Repositories.PokerPlanning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgileHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly ILogger<UsersController> logger;

        public UsersController(IUserRepository userRepository, IMapper mapper, ILogger<UsersController> logger)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            logger.LogInformation("Something is being logged.");
            var users = await userRepository.GetAllAsync();
            return Ok(mapper.Map<List<UserDto>>(users));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UserDto>(user));
        }

        [HttpGet]
        [Route("GetByPlanningRoomId{planningRoomId:guid}")]
        public async Task<IActionResult> GetByPlanningRoomId([FromRoute] Guid planningRoomId)
        {
            var users = await userRepository.GetByPlanningRoomIdAsync(planningRoomId);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<UserDto>>(users));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
        {
            var user = mapper.Map<User>(createUserDto);
            user = await userRepository.CreateAsync(user);
            return CreatedAtAction(nameof(Create), new { id = user.Id }, mapper.Map<UserDto>(user));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = mapper.Map<User>(updateUserDto);
            user = await userRepository.UpdateAsync(id, user);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UserDto>(user));
        }

        [HttpPut]
        [Route("JoinRoom/{roomId:guid}/{userId:guid}")]
        public async Task<IActionResult> JoinPlanningRoom([FromRoute] Guid roomId, [FromRoute] Guid userId)
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            user.PlanningRoomId = roomId;
            user = await userRepository.UpdateAsync(userId, user);
            return Ok(mapper.Map<UserDto>(user));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var user = await userRepository.DeleteAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UserDto>(user));
        }
    }
}
