using AutoMapper;
using KDWalks.API.Models.DTO;
using KDWalks.API.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllDifficulties()
        {
            var walkDifficultiesDomain = await walkDifficultyRepository.GetAllAsync();
            var difficultiesDto = mapper.Map<List<WalkDifficultyDto>>(walkDifficultiesDomain);

            return Ok(difficultiesDto);
        }

        // GET: /api/walkdifficulties/{id}
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "reader")]
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

        // POST: /api/walkdifficulties
        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddWalkDifficulty(
            [FromBody] AddWalkDifficultyRequest addWalkDifficultyRequestDto)
        {
            // ✅ FluentValidation runs automatically here

            var walkDifficultyDomain =
                mapper.Map<Models.Domain.WalkDifficulty>(addWalkDifficultyRequestDto);

            walkDifficultyDomain =
                await walkDifficultyRepository.AddAsync(walkDifficultyDomain);

            var walkDifficultyDto =
                mapper.Map<WalkDifficultyDto>(walkDifficultyDomain);

            return CreatedAtAction(
                nameof(GetWalkDifficultyById),
                new { id = walkDifficultyDto.Id },
                walkDifficultyDto);
        }

        // PUT: /api/walkdifficulties/{id}
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateWalkDifficulty(
            [FromRoute] Guid id,
            [FromBody] UpdateWalkDifficultyRequest updateWalkDifficultyRequestDto)
        {
            // ✅ FluentValidation runs automatically here

            var walkDifficultyDomain =
                mapper.Map<Models.Domain.WalkDifficulty>(updateWalkDifficultyRequestDto);

            walkDifficultyDomain.Id = id;

            walkDifficultyDomain =
                await walkDifficultyRepository.UpdateAsync(walkDifficultyDomain);

            if (walkDifficultyDomain == null)
            {
                return NotFound();
            }

            var walkDifficultyDto =
                mapper.Map<WalkDifficultyDto>(walkDifficultyDomain);

            return Ok(walkDifficultyDto);
        }

        // DELETE: /api/walkdifficulties/{id}
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "writer")]
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
