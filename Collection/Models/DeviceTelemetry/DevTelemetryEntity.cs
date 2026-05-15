using Collection.Models.Device;

namespace Collection.Models.DeviceTelemetry
{
    public class DevTelemetryEntity
    {

        public Guid Id { get; set; } = Guid.CreateVersion7();

        // Навигационные свойства на родителя
        public Guid DeviceId { get; set; }
        public DeviceEntity Device { get; set; } = null!;
        public string? DevType { get; set; }

        public float? Tempreature { get; set; }
        public float? Pressure { get; set; }

        public int? BatteryLevel { get; set; }
        public string? Status { get; set; }
    }
}
