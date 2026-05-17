using Collection.DTO.DeviceTelemetry;
using System.Collections.Immutable;
namespace Collection.Service.DeviceTelemetry
{
    public interface IDeviceTelemetryService
    {
        Task<ImmutableArray<DeviceTelemetryResponseDTO>> GetAllAsync(CancellationToken ct = default);
        Task<DeviceTelemetryResponseDTO> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task CreateAsync(DeviceTelemetryRequestDTO request, Guid deviceId, CancellationToken ct = default);
        Task UpdateAsync(Guid id, DeviceTelemtryUpdateDTO update, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
