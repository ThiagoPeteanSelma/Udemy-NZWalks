using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class AddWalkRequestDTO
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public required string Description { get; set; }
        [Required]
        [Range(0, 50)]
        public required double LengthInKm { get; set; }
        public string? WalkImageUrl { get; }

        [Required]
        public required Guid DifficultyId { get; set; }
        [Required]
        public required Guid RegionId { get; set; }
    }
}
