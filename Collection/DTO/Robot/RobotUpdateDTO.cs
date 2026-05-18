using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.Robot
{
    public class RobotUpdateDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage ="More than 50 chars")]
        public string DevAlias { get;  init; } = null!;
    }
}
