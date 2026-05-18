

using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.Hub
{
    public class HubRequestDTO
    {
        [MaxLength(50, ErrorMessage ="More than 50 chars were entered")]
        public string? HubAlias { get; init; }

        public bool? IsActive { get; init; }
    }
}
