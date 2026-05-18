using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.User
{
    public class UserUpdateDTO
    {

        
        
        [Required]
        [MinLength(5, ErrorMessage = "Not less than 5 chars"), MaxLength(50, ErrorMessage = "More than 50 chars")]
        public string Name { get; init; } = null!;

        [Required]
        [MinLength(5, ErrorMessage = "Not less than 5 chars"), MaxLength(50, ErrorMessage = "More than 50 chars")]
        public string Surname { get; init; } = null!;

        [Required]
        [Range(0, 120, ErrorMessage ="Must be between 0 and 120")]
        public int Age { get; init; }
    }
}
