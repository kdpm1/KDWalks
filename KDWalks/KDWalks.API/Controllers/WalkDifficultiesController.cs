using AutoMapper;
using KDWalks.API.Models.DTO;
using KDWalks.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KDWalks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalkDifficultiesController : ControllerBase
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultiesController(
            IWalkDifficultyRepository walkDifficultyRepository,
            IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }

        // GET: /api/walkdifficulties
        [HttpGet]
        public async Task<IActionResult> GetAllDifficulties()
        {
            var walkDifficultiesDomain = await walkDifficultyRepository.GetAllAsync();
            var difficultiesDto = mapper.Map<List<WalkDifficultyDto>>(walkDifficultiesDomain);

            return Ok(difficultiesDto);
        }

        // GET: /api/walkdifficulties/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetWalkDifficultyById([FromRoute] Guid id)
        {
            var walkDifficultyDomain = await walkDifficultyRepository.GetAsync(id);

            if (walkDifficultyDomain == null)
            {
                return NotFound();
            }

            var walkDifficultyDto =
                mapper.Map<WalkDifficultyDto>(walkDifficultyDomain);

            return Ok(walkDifficultyDto);
        }
        [HttpPost]
        public async Task<IActionResult> AddWalkDifficulty(
            [FromBody] AddWalkDifficultyRequest addWalkDifficultyRequestDto)
        {
            // Convert DTO to Domain Model
            var walkDifficultyDomain =
                mapper.Map<Models.Domain.WalkDifficulty>(addWalkDifficultyRequestDto);
            // Pass details to Repository
            walkDifficultyDomain =
                await walkDifficultyRepository.AddAsync(walkDifficultyDomain);
            // Convert back to DTO
            var walkDifficultyDto =
                mapper.Map<WalkDifficultyDto>(walkDifficultyDomain);
            // Return response
            return CreatedAtAction(
                nameof(GetWalkDifficultyById),
                new { id = walkDifficultyDto.Id },
                walkDifficultyDto);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkDifficulty(
            [FromRoute] Guid id,
            [FromBody] AddWalkDifficultyRequest updateWalkDifficultyRequestDto)
        {
            // Convert DTO to Domain Model
            var walkDifficultyDomain =
                mapper.Map<Models.Domain.WalkDifficulty>(updateWalkDifficultyRequestDto);
            walkDifficultyDomain.Id = id;
            // Pass details to Repository
            walkDifficultyDomain =
                await walkDifficultyRepository.UpdateAsync(walkDifficultyDomain);
            // Handle null (not found)
            if (walkDifficultyDomain == null)
            {
                return NotFound();
            }
            // Convert back to DTO
            var walkDifficultyDto =
                mapper.Map<WalkDifficultyDto>(walkDifficultyDomain);
            // Return response
            return Ok(walkDifficultyDto);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkDifficulty([FromRoute] Guid id)
        {
            var walkDifficultyDomain = await walkDifficultyRepository.DeleteAsync(id);
            if (walkDifficultyDomain == null)
            {
                return NotFound();
            }
            var walkDifficultyDto =
                mapper.Map<WalkDifficultyDto>(walkDifficultyDomain);
            return Ok(walkDifficultyDto);
        }
    }
}
