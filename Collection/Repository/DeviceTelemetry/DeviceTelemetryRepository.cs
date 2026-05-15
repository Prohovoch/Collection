using Collection.Models.DeviceTelemetry;
using IoT.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Collection.Repository.DeviceTelemetry
{
    public class DeviceTelemetryRepository:IDeviceTelemetry
    {
        private readonly ApplicationDbContext _context;

        public DeviceTelemetryRepository(ApplicationDbContext Context)
        {
            _context = Context;
        }


        public async Task<IReadOnlyList<DevTelemetryEntity>> GetAllAsync(CancellationToken ct = default) =>
            await _context.DeviceTelemetries.AsNoTracking().ToListAsync(ct);
        public async Task<DevTelemetryEntity?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
            await _context.DeviceTelemetries.FirstOrDefaultAsync(t => t.Id == id, ct);

        public async Task<int> DeleteTelemAsync(Guid id, CancellationToken ct = default) =>
            await _context.DeviceTelemetries.Where(t => t.Id == id).ExecuteDeleteAsync(ct);
        public void CreateTelemetry(DevTelemetryEntity telemetry)
        {
            _context.DeviceTelemetries.Add(telemetry);
        }

        public async Task UpdateTelemData(Guid id, DevTelemetryEntity telemetry, CancellationToken ct = default) =>
            await _context.DeviceTelemetries.Where(t => t.Id == id).ExecuteUpdateAsync(t => t.SetProperty(t => t.Tempreature, t => telemetry.Tempreature)
            .SetProperty(t => t.BatteryLevel, t => telemetry.BatteryLevel)
            .SetProperty(t => t.Pressure, t => telemetry.Pressure)
            .SetProperty(t => t.Status, t => telemetry.Status), ct
            );

        public async Task SaveChangesAsync(CancellationToken ct = default) => await _context.SaveChangesAsync(ct);
    }
}
}
