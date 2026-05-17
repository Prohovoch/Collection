using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.User
{
    public class UserRequestDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Surname is required")]
        [MaxLength(50)]
        public string Surname { get; set; } = null!;

        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120")]
        public int? Age { get; set; }
    }
}
