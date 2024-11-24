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
    public class PlanningRoomsController : ControllerBase
    {
        private readonly IPlanningRoomRepository planningRoomRepository;
        private readonly IMapper mapper;

        public PlanningRoomsController(IPlanningRoomRepository planningRoomRepository, IMapper mapper)
        {
            this.planningRoomRepository = planningRoomRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var planningRooms = await planningRoomRepository.GetAllAsync();
            return Ok(mapper.Map<List<PlanningRoomDto>>(planningRooms));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var planningRoom = await planningRoomRepository.GetByIdAsync(id);
            if (planningRoom == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PlanningRoomDto>(planningRoom));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreatePlanningRoomDto createPlanningRoomDto)
        {
            var planningRoom = mapper.Map<PlanningRoom>(createPlanningRoomDto);
            planningRoom = await planningRoomRepository.CreateAsync(planningRoom);
            return CreatedAtAction(nameof(Create), new { id = planningRoom.Id }, mapper.Map<PlanningRoomDto>(planningRoom));
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePlanningRoomDto updatePlanningRoomDto)
        {
            var planningRoom = mapper.Map<PlanningRoom>(updatePlanningRoomDto);
            planningRoom = await planningRoomRepository.UpdateAsync(id, planningRoom);
            if (planningRoom == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PlanningRoomDto>(planningRoom));
        }        

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var planningRoom = await planningRoomRepository.DeleteAsync(id);
            if (planningRoom == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PlanningRoomDto>(planningRoom));
        }
    }
}
