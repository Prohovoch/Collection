using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.Device
{
    public class DeviceRequestDTO
    {
        [MaxLength(50, ErrorMessage ="More than 50 chars were entered")]
        public string? DevAlias { get; set; }

    }
}
