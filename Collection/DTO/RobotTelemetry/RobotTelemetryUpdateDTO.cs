using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.RobotTelemetry
{
    // DTO for UPDATE REQ

    public class RobotTelemetryUpdateDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage = "More than 50 chars")]
        public string RobotType { get; set; } = null!;
        [Required]
        [MaxLength(50, ErrorMessage = "More than 50 chars")]
        public string Status { get; set; } = null!;
        [Required]
        public int PosX { get; set; }
        [Required]
        public int PosY { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage ="Must be between 0 and 100")]
        public int Battery { get; set; }
        [Required]
        public float Speed { get; set; }

    }
}
