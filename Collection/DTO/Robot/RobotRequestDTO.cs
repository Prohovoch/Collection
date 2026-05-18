using System.ComponentModel.DataAnnotations;

namespace Collection.DTO.Robot
{
    public class RobotRequestDTO
    {
        [MaxLength(50, ErrorMessage ="More than 50 chars")]
        public string? DevAlias { get; init; }
    }
}
