using Collection.Models.DeviceTelemetry;

namespace Collection.Repository.DeviceTelemetry
{
    public interface IDeviceTelemetry
    {
        Task<IReadOnlyList<DevTelemetryEntity>> GetAllAsync(CancellationToken ct = default);
        Task<DevTelemetryEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<int> DeleteTelemAsync(Guid id, CancellationToken ct = default);
        public void CreateTelemetry(DevTelemetryEntity telemetry);
        Task UpdateTelemData(Guid id, DevTelemetryEntity telemetry, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
