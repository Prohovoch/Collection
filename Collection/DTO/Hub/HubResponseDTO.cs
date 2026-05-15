using Collection.DTO.Robot;
using Collection.DTO.Device;
namespace Collection.DTO.Hub
{
    public class HubResponseDTO
    {
        public Guid Id { get; init; }
        public string? HubAlias { get; init; }

        public bool? IsActive { get; init; }

        public Guid UserId { get; init; }
    }

    public class HubResponseExtraDTO : HubResponseDTO
    {
        public IReadOnlyList<DeviceResponseDTO>? Devices { get; init; }
        public IReadOnlyList<RobotResponseDTO>? Robots { get; init; }
        // ICollection<...>  Robots {get; init} = new List<Robots>()
    }
}

