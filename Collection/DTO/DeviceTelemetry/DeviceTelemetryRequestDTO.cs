using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.DeviceTelemetry
{
    public class DeviceTelemetryRequestDTO
    {
        [MaxLength(50, ErrorMessage ="More than 50 chars")]
        public string? DevType { get; init; }
        public float? Temp { get; init; }
        public float? Press { get; init; }

        [Range(0, 100, ErrorMessage ="Value must be between 0 and 100")]
        public int? BattLevel { get; init; }
        [MaxLength(50, ErrorMessage="More than 50 chars")]
        public string? Status { get; init; }

    }
}
