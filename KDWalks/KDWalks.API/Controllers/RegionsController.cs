using AutoMapper;
using KDWalks.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KDWalks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(
            IRegionRepository regionRepository,
            IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET: /api/regions
        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetAllAsync();
            var regionsDto = mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDto);
        }

        // GET: /api/regions/{id}
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "reader")]

        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDto);
        }

        // POST: /api/regions
        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddRegionAsync(
            [FromBody] Models.DTO.AddRegionRequest addRegionRequest)
        {
            // ✅ FluentValidation runs automatically here

            var region = mapper.Map<Models.Domain.Region>(addRegionRequest);
            region = await regionRepository.AddAsync(region);

            var regionDto = mapper.Map<Models.DTO.Region>(region);

            return CreatedAtAction(
                nameof(GetRegionAsync),
                new { id = regionDto.Id },
                regionDto);
        }

        // PUT: /api/regions/{id}
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> UpdateRegionAsync(
            [FromRoute] Guid id,
            [FromBody] Models.DTO.UpdateRegionRequest updateRegionRequest)
        {
            // ✅ FluentValidation runs automatically here

            var region = mapper.Map<Models.Domain.Region>(updateRegionRequest);
            region = await regionRepository.UpdateAsync(id, region);

            if (region == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDto);
        }

        // DELETE: /api/regions/{id}

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await regionRepository.DeleteAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDto);
        }
    }
}
