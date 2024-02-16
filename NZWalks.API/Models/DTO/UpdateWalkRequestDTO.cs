namespace NZWalks.API.Models.DTO
{
    public class UpdateWalkRequestDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; }
    }
}
