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

        public IReadOnlyList<RobotTelemResponseDTO>? RobTelemetry { get; init; }

    }
}
    

