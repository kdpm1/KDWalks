using AutoMapper;
using KDWalks.API.Models.Domain;
using KDWalks.API.Models.DTO;

namespace KDWalks.API.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            // Domain ↔ DTO
            CreateMap<Walk, WalkDto>().ReverseMap();

            // POST
            CreateMap<AddWalkRequest, Walk>();

            // PUT  ✅ THIS FIXES THE 500 ERROR
            CreateMap<UpdateWalkRequest, Walk>();

            // Walk Difficulty
            CreateMap<WalkDifficulty, WalkDifficultyDto>().ReverseMap();
        }
    }
}
