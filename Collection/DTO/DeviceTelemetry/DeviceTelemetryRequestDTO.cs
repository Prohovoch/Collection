using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.DeviceTelemetry
{
    public class DeviceTelemetryRequestDTO
    {
        public string? DevType { get; set; }
        public float? Temp { get; set; }
        public float? Press { get; set; }

 
        public int? BattLevel { get; set; }
        public string? Status { get; set; }

    }
}
