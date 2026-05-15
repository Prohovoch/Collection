using Collection.Models.Device;
using IoT.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Collection.Repository.Device
{
    public class DeviceRepository:IDeviceRepository
    {
        private readonly ApplicationDbContext _context;
        public DeviceRepository(ApplicationDbContext Context)
        {

            _context = Context;

        }

        public async Task<IReadOnlyList<DeviceEntity>> GetAllAsync(CancellationToken ct = default) =>
            await _context.Devices.AsNoTracking().ToListAsync(ct);


        public async Task<DeviceEntity?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
            await _context.Devices.FirstOrDefaultAsync(d => d.Id == id, ct);


        public async Task<DeviceEntity?> GetByIdTelemAsync(Guid id, CancellationToken ct = default) =>
            await _context.Devices.Include(d => d.Telemetry).FirstOrDefaultAsync(d => d.Id == id, ct);

        public async Task<int> DeleteDeviceAsync(Guid id, CancellationToken ct = default) =>
            await _context.Devices.Where(d => d.Id == id).ExecuteDeleteAsync(ct);
        public void CreateDevice(DeviceEntity device)
        {
            _context.Devices.Add(device);
        }

        public async Task UpdateDeviceData(Guid id, DeviceEntity device, CancellationToken ct = default) =>
            await _context.Devices.Where(d => d.Id == id).ExecuteUpdateAsync(d => d.SetProperty(d => d.DevAlias, d => device.DevAlias), ct);
        public async Task SaveChangesAsync(CancellationToken ct = default) => await _context.SaveChangesAsync(ct);


    }
}
