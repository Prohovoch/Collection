using System.Collections.Immutable;
using Collection.DTO.Device;
namespace Collection.Service.Device
{
    public interface IDeviceService
    {
        Task<ImmutableArray<DeviceResponseDTO>> GetAllAsync(CancellationToken ct = default);
        Task<DeviceResponseDTO> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<DeviceResponseExtraDTO> GetByIdWithTelemAsync(Guid id, CancellationToken ct = default);
        Task CreateDevice(DeviceRequestDTO request, Guid hubId, CancellationToken ct);
        Task UpdateDevice(Guid id, DeviceUpdateDTO update, CancellationToken ct = default);
        Task DeleteDevice(Guid id, CancellationToken ct = default);
    }
}
