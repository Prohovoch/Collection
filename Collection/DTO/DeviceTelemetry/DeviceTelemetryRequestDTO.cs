using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.DeviceTelemetry
{
    public class DeviceTelemetryRequestDTO
    {
        [MaxLength(50, ErrorMessage ="More than 50 chars")]
        public string? DevType { get; set; }
        public float? Temp { get; set; }
        public float? Press { get; set; }

        [Range(0, 100, ErrorMessage ="Value must be between 0 and 100")]
        public int? BattLevel { get; set; }
        [MaxLength(50, ErrorMessage="More than 50 chars")]
        public string? Status { get; set; }

    }
}
