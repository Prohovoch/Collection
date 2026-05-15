namespace Collection.DTO.RobotTelemetry
{
    public class RobotTelemetryResponseDTO
    {
        public Guid Id { get; init; }
        public Guid RobotId { get; init; }

        public string? RobotType { get; init; }

        public string? Status { get; init; }
        public float? PosX { get; init; }
        public float? PosY { get; init; }

        public int? Battery { get; init; }

        public float? Speed { get; init; }
    }
}
