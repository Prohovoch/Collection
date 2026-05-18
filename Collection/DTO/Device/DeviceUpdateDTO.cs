using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.Device
{
    public class DeviceUpdateDTO
    {
        [Required]
        [MinLength(5, ErrorMessage = "Not less than 5 chars"), MaxLength(50, ErrorMessage ="More than 50 chars were entered")]
        public string DevAlias { get; set; } = null!;
    }
}
