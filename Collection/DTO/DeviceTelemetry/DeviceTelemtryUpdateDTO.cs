using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.DeviceTelemetry
{
    public class DeviceTelemtryUpdateDTO
    {
        [Required]
        public float Temp { get; set; }
        [Required]
        public float Press { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage ="Value must be between 0 and 100")]
        public int BattLevel { get; set; }
        [Required]
        [MinLength(5, ErrorMessage ="Not less than 5 chars"),MaxLength(50, ErrorMessage ="More than 50 chars")]
        public string Status { get; set; } = null!;

    }
}
