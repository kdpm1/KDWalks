namespace KDWalks.API.Models.DTO
{
    public class AddWalkRequest
    {
        public string Name { get; set; } = null!;
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

    }
}
