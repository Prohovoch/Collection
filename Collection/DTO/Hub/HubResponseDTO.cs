using Collection.DTO.Robot;
using Collection.DTO.Device;
using System.Collections.Immutable;
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
        public ImmutableArray<DeviceResponseDTO>? Devices { get; init; }
        public ImmutableArray<RobotResponseDTO>? Robots { get; init; }
        // ICollection<...>  Robots {get; init} = new List<Robots>()
    }
}

