using Collection.Models.Robot;

namespace Collection.Models.RobotTelemetry
{
    public class RobTelemetryEntity
    {

        public Guid Id { get; set; } = Guid.CreateVersion7();
        // Навигационные свойства родителя
        public Guid RobotId { get; set; }
        public RobotEntity Robot { get; set; } = null!;
        public string? DevType { get; set; }

        public float? PositionX { get; set; }
        public float? PositionY { get; set; }

        public int? BatteryLevel { get; set; }
        public float? Speed { get; set; }

        public string? Status { get; set; }
    }
}
