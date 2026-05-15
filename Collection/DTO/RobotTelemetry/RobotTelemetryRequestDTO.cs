using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.RobotTelemetry
{
    public class RobotTelemetryRequestDTO
    {
       
        public string? RobotType { get; set; }
      
        public string? Status { get; set; }
       
        public float? PosX { get; set; }
       
        public float? PosY { get; set; }
       
        public int? Battery { get; set; }
        public float? Speed { get; set; }
    }
}
