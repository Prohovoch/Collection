using Collection.Models.RobotTelemetry;
using Collection.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Collection.Repository.RobotTelemetry
{
    public class RobotTelemetryRepository:IRobotTelemetry
    {
        private readonly ApplicationDbContext _Context;

        public RobotTelemetryRepository(ApplicationDbContext Context)
        {

            _Context = Context;

        }


        public async Task<IReadOnlyCollection<RobTelemetryEntity>> GetAllAsync(CancellationToken ct = default) =>
            await _Context.RobotTelemetries.AsNoTracking().ToListAsync(ct);
        public async Task<RobTelemetryEntity?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
            await _Context.RobotTelemetries.Where(rt => rt.Id == id).FirstOrDefaultAsync(ct);
        public async Task<int> DeleteTelemAsync(Guid id, CancellationToken ct = default) =>
            await _Context.RobotTelemetries.Where(rt => rt.Id == id).ExecuteDeleteAsync(ct);

        public void CreateTelemetry(RobTelemetryEntity telemetry) => _Context.RobotTelemetries.Add(telemetry);

        public async Task UpdateTelemData(Guid id, RobTelemetryEntity telemetry, CancellationToken ct = default) =>
            await _Context.RobotTelemetries.Where(rt => rt.Id == id).ExecuteUpdateAsync(rt => rt.SetProperty(
                rt => rt.PositionX, rt => telemetry.PositionX)
            .SetProperty(rt => rt.PositionY, rt => telemetry.PositionY)
            .SetProperty(rt => rt.Status, rt => telemetry.Status)
            .SetProperty(rt => rt.Speed, rt => telemetry.Speed)
            .SetProperty(rt => rt.BatteryLevel, rt => telemetry.BatteryLevel), ct);

        public async Task SaveChangesAsync(CancellationToken ct = default) => await _Context.SaveChangesAsync(ct);
    }
}
