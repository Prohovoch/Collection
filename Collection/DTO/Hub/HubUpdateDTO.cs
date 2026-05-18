using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.Hub
{
    public class HubUpdateDTO
    {

        [Required]
        [MinLength(5, ErrorMessage = "Not less than 5 chars"), MaxLength(50, ErrorMessage = "More than 50 chars")]
        public string HubAlias { get; init; } = null!;

        [Required]
        
        public bool IsActive { get; init; }

    }
}
