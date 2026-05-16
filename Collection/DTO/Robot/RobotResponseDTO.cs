using Collection.DTO.RobotTelemetry;
using System.Collections.Immutable;
namespace Collection.DTO.Robot
{
    public class RobotResponseDTO
    {

        public Guid Id { get; init; }
        public Guid HubId { get; init; }
        public string? DevAlias { get; init; }


    }

    public class RobotResponseExtraDTO : RobotResponseDTO
    {

        public RobotTelemetryResponseDTO? RobTelemetry { get; init; }

    }
}
    

