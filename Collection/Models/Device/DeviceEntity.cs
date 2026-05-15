using Collection.Models.Hub;
using Collection.Models.DeviceTelemetry;
namespace Collection.Models.Device
{
    public class DeviceEntity
    {
            public Guid Id { get; set; } = Guid.CreateVersion7();
            
            // Навигационное свойство на родителя
            public Guid HubId { get; set; }

            public HubEntity Hub { get; set; } = null!;
            
            public string? DevAlias { get; set; }

            /*
             * 1 to 1 relation ship
             */
            public DevTelemetryEntity? Telemetry { get; set; }
        }
    }
    

