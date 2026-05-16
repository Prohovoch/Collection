using Collection.Models.Device;

namespace Collection.Repository.Device
{
    public interface IDeviceRepository
    {
        Task<IReadOnlyCollection<DeviceEntity>> GetAllAsync(CancellationToken ct = default);
        Task<DeviceEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
       
        Task<DeviceEntity?> GetByIdTelemAsync(Guid id, CancellationToken ct = default);
        Task<int> DeleteDeviceAsync(Guid id, CancellationToken ct = default);
        public void CreateDevice(DeviceEntity device);
        Task UpdateDeviceData(Guid id, DeviceEntity device, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
