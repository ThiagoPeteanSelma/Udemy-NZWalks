namespace NZWalks.API.Models.DTO
{
    public class AddWalkRequestDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required double LengthInKm { get; set; }
        public string? WalkImageUrl { get; }

        public required Guid DifficultyId { get; set; }
        public required Guid RegionId { get; set; }
    }
}
