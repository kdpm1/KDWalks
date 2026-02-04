using AutoMapper;
using KDWalks.API.Models.Domain;
using KDWalks.API.Models.DTO;
using KDWalks.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KDWalks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        // GET: /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var walksDomain = await walkRepository.GetAllAsync();
            var walksDto = mapper.Map<List<WalkDto>>(walksDomain);

            return Ok(walksDto);
        }

        // GET: /api/walks/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetWalkAsync([FromRoute] Guid id)
        {
            var walkDomain = await walkRepository.GetAsync(id);

            if (walkDomain == null)
            {
                return NotFound();
            }

            var walkDto = mapper.Map<WalkDto>(walkDomain);
            return Ok(walkDto);
        }

        // POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> AddWalkAsync(
            [FromBody] AddWalkRequest addWalkRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var walkDomain = mapper.Map<Walk>(addWalkRequest);
            walkDomain = await walkRepository.AddAsync(walkDomain);

            var walkDto = mapper.Map<WalkDto>(walkDomain);

            return CreatedAtAction(
                nameof(GetWalkAsync),
                new { id = walkDto.Id },
                walkDto
            );
        }

        // PUT: /api/walks/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync(
            [FromRoute] Guid id,
            [FromBody] UpdateWalkRequest updateWalkRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var walkDomain = mapper.Map<Walk>(updateWalkRequest);
            walkDomain.Id = id;

            var updatedWalk = await walkRepository.UpdateAsync(walkDomain);

            if (updatedWalk == null)
            {
                return NotFound();
            }

            var walkDto = mapper.Map<WalkDto>(updatedWalk);
            return Ok(walkDto);
        }
        // DELETE: /api/walks/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync([FromRoute] Guid id)
        {
            var deletedWalk = await walkRepository.DeleteAsync(id);
            if (deletedWalk == null)
            {
                return NotFound();
            }
            var walkDto = mapper.Map<WalkDto>(deletedWalk);
            return Ok(walkDto);
        }

    }
}
