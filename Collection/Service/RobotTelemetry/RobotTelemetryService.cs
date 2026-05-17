using Collection.Models.RobotTelemetry;
using Collection.Repository.RobotTelemetry;
using System.Collections.Immutable;
using Collection.DTO.RobotTelemetry;

namespace Collection.Service.RobotTelemetry
{
    public class RobotTelemetryService
    {
        private readonly IRobotTelemetry _robTelemRepository;

        public RobotTelemetryService(IRobotTelemetry robTelemRepository)
        {
            _robTelemRepository = robTelemRepository;
        }

        public async Task<ImmutableArray<RobotTelemetryResponseDTO>> GetAllAsync(CancellationToken ct = default)
        {
            var telemetries = await _robTelemRepository.GetAllAsync(ct);
            return [.. telemetries.Select(t => new RobotTelemetryResponseDTO
            {
                Id = t.Id,
                RobotId = t.RobotId,
                RobotType = t.DevType,
                Status = t.Status,
                PosX = t.PositionX,
                PosY = t.PositionY,
                Battery = t.BatteryLevel,
                Speed = t.Speed
            })];
        }

        public async Task<RobotTelemetryResponseDTO> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var telemetry = await _robTelemRepository.GetByIdAsync(id, ct);
            if (telemetry is null)
                throw new KeyNotFoundException($"Telemetry {id} not found");

            return new RobotTelemetryResponseDTO
            {
                Id = telemetry.Id,
                RobotId = telemetry.RobotId,
                RobotType = telemetry.DevType,
                Status = telemetry.Status,
                PosX = telemetry.PositionX,
                PosY = telemetry.PositionY,
                Battery = telemetry.BatteryLevel,
                Speed = telemetry.Speed
            };
        }

        public async Task CreateAsync(
            RobotTelemetryRequestDTO request,
            Guid robotId,
            CancellationToken ct = default)
        {
            var entity = new RobTelemetryEntity
            {
                RobotId = robotId,
                DevType = request.RobotType,
                Status = request.Status,
                PositionX = request.PosX,
                PositionY = request.PosY,
                BatteryLevel = request.Battery,
                Speed = request.Speed
            };

            _robTelemRepository.CreateTelemetry(entity);
            await _robTelemRepository.SaveChangesAsync(ct);

          
        }

        public async Task UpdateAsync(Guid id, RobotTelemetryUpdateDTO update, CancellationToken ct = default)
        {
            var telemetry = await _robTelemRepository.GetByIdAsync(id, ct);
            if (telemetry is null)
                throw new KeyNotFoundException($"Telemetry {id} not found");

          
            telemetry.DevType = update.RobotType;
            telemetry.Status = update.Status;
            telemetry.PositionX = update.PosX;
            telemetry.PositionY = update.PosY;
            telemetry.BatteryLevel = update.Battery;
            telemetry.Speed = update.Speed;

            await _robTelemRepository.UpdateTelemData(id, telemetry, ct);
        }
        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var affected = await _robTelemRepository.DeleteTelemAsync(id, ct);
            if (affected == 0)
            {
                throw new KeyNotFoundException($"Telemetry {id} not found");
            }
        }
    }
}
    
