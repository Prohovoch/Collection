using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.Hub
{
    public class HubUpdateDTO
    {

        [Required]
        [MaxLength(50, ErrorMessage ="More than 50 chars")]
        public string HubAlias { get; set; } = null!;

        [Required]
        
        public bool IsActive { get; set; }

    }
}
