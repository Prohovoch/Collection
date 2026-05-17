using Collection.Models.DeviceTelemetry;
using Collection.Repository.DeviceTelemetry;
using Collection.DTO.DeviceTelemetry;
using System.Collections.Immutable;
namespace Collection.Service.DeviceTelemetry
{
    public class DeviceTelemetryService:IDeviceTelemetryService
    {
        private readonly IDeviceTelemetry _telemRepository;

        public DeviceTelemetryService(IDeviceTelemetry telemRepository)
        {
            _telemRepository = telemRepository;
        }

        public async Task<ImmutableArray<DeviceTelemetryResponseDTO>> GetAllAsync(CancellationToken ct = default)
        {
            var telemetries = await _telemRepository.GetAllAsync(ct);
            return [.. telemetries.Select(t => new DeviceTelemetryResponseDTO
            {
                Id = t.Id,
                DeviceId = t.DeviceId,
                DevType = t.DevType,
                Temp = t.Tempreature,
                Press = t.Pressure,
                BattLevel = t.BatteryLevel,
                Status = t.Status
            })];
        }

        public async Task<DeviceTelemetryResponseDTO> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var telemetry = await _telemRepository.GetByIdAsync(id, ct) ?? throw new KeyNotFoundException($"Telemetry {id} not found");
            return new DeviceTelemetryResponseDTO
            {
                Id = telemetry.Id,
                DeviceId = telemetry.DeviceId,
                DevType = telemetry.DevType,
                Temp = telemetry.Tempreature,
                Press = telemetry.Pressure,
                BattLevel = telemetry.BatteryLevel,
                Status = telemetry.Status
            };
        }

        public async Task CreateAsync(
            DeviceTelemetryRequestDTO request,
            Guid deviceId,
            CancellationToken ct = default)
        {
            var entity = new DevTelemetryEntity
            {
                DeviceId = deviceId,
                DevType = request.DevType,
                Tempreature = request.Temp,
                Pressure = request.Press,
                BatteryLevel = request.BattLevel,
                Status = request.Status
            };

            _telemRepository.CreateTelemetry(entity);
            await _telemRepository.SaveChangesAsync(ct);

         
        }

        public async Task UpdateAsync(Guid id, DeviceTelemtryUpdateDTO update, CancellationToken ct = default)
        {
            var telemetry = await _telemRepository.GetByIdAsync(id, ct) ?? throw new KeyNotFoundException($"Telemetry {id} not found");
            telemetry.Tempreature = update.Temp;
            telemetry.Pressure = update.Press;
            telemetry.BatteryLevel = update.BattLevel;
            telemetry.Status = update.Status;

            await _telemRepository.UpdateTelemData(id, telemetry, ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var affected = await _telemRepository.DeleteTelemAsync(id, ct);
            if (affected == 0)
            {
                throw new KeyNotFoundException($"Telemetry {id} not found");
            }
        }
    }
}

