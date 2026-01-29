using AutoMapper;
using KDWalks.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KDWalks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetAllAsync();
            //return Dto region

            //var regionsDto = new List<Models.DTO.Region>();
          //  regionRepository.GetAll().ToList().ForEach(region =>
         //   {
               // var regionDto = new Models.DTO.Region()
                ////{
                  //  Id = region.Id,
                   // Code = region.Code,
                 //   Name = region.Name,
                   // Area = region.Area,
                   // Lat = region.Lat,
                   // Long = region.Long,
                    //Population = region.Population
              //  };
             //   regionsDto.Add(regionDto);
           // });
           var regionsDto = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDto);
        }
    }
}