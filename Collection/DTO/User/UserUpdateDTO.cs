using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.User
{
    public class UserUpdateDTO
    {

        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage ="More than 50 chars")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(50, ErrorMessage = "More than 50 chars")]
        public string Surname { get; set; } = null!;

        [Required]
        [Range(0, 120, ErrorMessage ="Must be between 0 and 120")]
        public int Age { get; set; }
    }
}
