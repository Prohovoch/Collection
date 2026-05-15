using Collection.Models.Hub;

namespace Collection.Models.Robot
{
    public class RobotEntity
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();

        /*
         * Навигационные свойства
         */
        public Guid HubId { get; set; }

        public HubEntity Hub { get; set; } = null!;
        public string? DevAlias { get; set; }

        /*
       * 1 to 1 relation ship
       */
        public RobTelemetryEntity? Telemetry { get; set; }
    }
}
