using AgileHub.Api.Models.Domain.PokerPlanning;
using AgileHub.Api.Models.DTO.PokerPlanning;
using AgileHub.Api.Repositories.PokerPlanning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgileHub.Api.Controllers.PokerPlanning
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimationSystemsController : ControllerBase
    {
        private readonly IEstimationSystemRepository estimationSystemRepository;
        private readonly IMapper mapper;

        public EstimationSystemsController(
            IEstimationSystemRepository estimationSystemRepository,
            IMapper mapper
        )
        {
            this.estimationSystemRepository = estimationSystemRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estimationSystems = await estimationSystemRepository.GetAllAsync();
            return Ok(mapper.Map<List<EstimationSystemDto>>(estimationSystems));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var estimationSystem = await estimationSystemRepository.GetByIdAsync(id);
            if (estimationSystem == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<EstimationSystemDto>(estimationSystem));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateEstimationSystemDto createEstimationSystemDto
        )
        {
            var estimationSystem = new EstimationSystem
            {
                Name = createEstimationSystemDto.Name,
                Values = createEstimationSystemDto.Values.Split(',').ToList(),
            };

            estimationSystem = await estimationSystemRepository.CreateAsync(estimationSystem);
            return CreatedAtAction(
                nameof(Create),
                new { id = estimationSystem.Id },
                mapper.Map<EstimationSystemDto>(estimationSystem)
            );
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateEstimationSystemDto updateEstimationSystemDto
        )
        {
            var estimationSystem = new EstimationSystem
            {
                Name = updateEstimationSystemDto.Name,
                Values = updateEstimationSystemDto.Values.Split(",").ToList(),
            };

            estimationSystem = await estimationSystemRepository.UpdateAsync(id, estimationSystem);
            if (estimationSystem == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<EstimationSystemDto>(estimationSystem));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var estimationSystem = await estimationSystemRepository.DeleteAsync(id);
            if (estimationSystem == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<EstimationSystemDto>(estimationSystem));
        }
    }
}
