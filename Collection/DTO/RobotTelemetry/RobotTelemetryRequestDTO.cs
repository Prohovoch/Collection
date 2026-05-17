using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.RobotTelemetry
{
    public class RobotTelemetryRequestDTO
    {
        [MaxLength(50, ErrorMessage ="More than 50 chars")]
        public string? RobotType { get; set; }
        [MaxLength(50, ErrorMessage = "More than 50 chars")]
        public string? Status { get; set; }
       
        public float? PosX { get; set; }
       
        public float? PosY { get; set; }
        [Range(0, 100, ErrorMessage ="Must be between 0 and 100")]
        public int? Battery { get; set; }
        public float? Speed { get; set; }
    }
}
