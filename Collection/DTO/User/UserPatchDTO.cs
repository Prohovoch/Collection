using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.User
{
    public class UserPatchDTO
    {
        // В отличии от PUT, PATCH ожидает нулевые поля.\
        [MaxLength(50, ErrorMessage ="More than 50 chars")]
        public string? Name { get; init; }
        [MaxLength(50, ErrorMessage ="More than 50 chars"), ]
        public string? Surname { get; init; }

        [Range(1, 120, ErrorMessage ="Value must be between 1 and 120")]
        public int? Age { get; init; }
    }
}
