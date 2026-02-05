using AutoMapper;
using KDWalks.API.Models.Domain;
using KDWalks.API.Models.DTO;

namespace KDWalks.API.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            // Walk
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<AddWalkRequest, Walk>();
            CreateMap<UpdateWalkRequest, Walk>();

            // Walk Difficulty  ✅ THIS WAS MISSING
            CreateMap<AddWalkDifficultyRequest, WalkDifficulty>();
            CreateMap<WalkDifficulty, WalkDifficultyDto>().ReverseMap();
        }
    }
}
