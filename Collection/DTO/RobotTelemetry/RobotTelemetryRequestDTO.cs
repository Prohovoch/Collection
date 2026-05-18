using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.RobotTelemetry
{
    public class RobotTelemetryRequestDTO
    {
        [MaxLength(50, ErrorMessage ="More than 50 chars")]
        public string? RobotType { get; init; }
        [MaxLength(50, ErrorMessage = "More than 50 chars")]
        public string? Status { get; init; }
       
        public float? PosX { get; init; }
       
        public float? PosY { get; init; }
        [Range(0, 100, ErrorMessage ="Must be between 0 and 100")]
        public int? Battery { get; init; }
        public float? Speed { get; init; }
    }
}
