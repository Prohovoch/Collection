namespace Collection.DTO.DeviceTelemetry
{
    public class DeviceTelemetryResponseDTO
    {
        public Guid Id { get; init; }
        public Guid DeviceId { get; init; }


        public string? DevType { get; init; }

        public float? Temp { get; init; }
        public float? Press { get; init; }

        public int? BattLevel { get; init; }
        public string? Status { get; init; }
    }
}
