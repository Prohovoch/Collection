using Collection.DTO.DeviceTelemetry;
using System.Collections.Immutable;
namespace Collection.DTO.Device
{

    public class DeviceResponseDTO
    {
        public Guid Id { get; init; }
        public string? DevAlias { get; init; }
        public Guid HubId { get; init; }

    }

    public class DeviceResponseExtraDTO : DeviceResponseDTO
    {
        public DeviceTelemetryResponseDTO? DevTelem { get; init; }

    }
}
    

