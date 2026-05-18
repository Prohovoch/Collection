using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.RobotTelemetry
{
    // DTO for UPDATE REQ

    public class RobotTelemetryUpdateDTO
    {
        [Required]
        [MinLength(5, ErrorMessage = "Not less than 5 chars"), MaxLength(50, ErrorMessage = "More than 50 chars")]
        public string RobotType { get; init; } = null!;
        [Required]
        [MinLength(5, ErrorMessage = "Not less than 5 chars"), MaxLength(50, ErrorMessage = "More than 50 chars")]
        public string Status { get; init; } = null!;
        [Required]
        public int PosX { get; init; }
        [Required]
        public int PosY { get; init; }
        [Required]
        [Range(0, 100, ErrorMessage ="Must be between 0 and 100")]
        public int Battery { get; init; }
        [Required]
        public float Speed { get; init; }

    }
}
