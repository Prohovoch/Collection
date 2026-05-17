using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.Device
{
    public class DeviceUpdateDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage ="More than 50 chars were entered")]
        public string DevAlias { get; set; } = null!;
    }
}
