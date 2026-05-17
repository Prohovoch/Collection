using Collection.Models.Robot;
using Collection.Repository.Robot;
using Collection.DTO.Robot;
using Collection.DTO.RobotTelemetry;

using System.Collections.Immutable;
namespace Collection.Service.Robot
{
    // Service реализует логику работы с бд, проводит создание проекций, возвращает и выдает запросы.
    // Для полноты картины можно было бы выделить маппинг в отдельную категорию папок. Но из за ограничений сделал посабление по данному поводу.
    public class RobotService:IRobotService
    {
        private readonly IRobotRepository _robotRepository;

        public RobotService(IRobotRepository robotRepository)
        {
            _robotRepository = robotRepository;
        }

        public async Task<ImmutableArray<RobotResponseDTO>> GetAllAsync(CancellationToken ct = default)
        {
            var robots = await _robotRepository.GetAllAsync(ct);
            return [.. robots.Select(r => new RobotResponseDTO
            {
                Id = r.Id,
                DevAlias = r.DevAlias,
                HubId = r.HubId
            })];
        }

        public async Task<RobotResponseDTO> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var robot = await _robotRepository.GetByIdAsync(id, ct) ?? throw new KeyNotFoundException($"Robot {id} not found");
            return new RobotResponseDTO
            {
                Id = robot.Id,
                DevAlias = robot.DevAlias,
                HubId = robot.HubId
            };
        }

        public async Task<RobotResponseExtraDTO> GetByIdWithTelemAsync(Guid id, CancellationToken ct = default)
        {
            var robot = await _robotRepository.GetByIdTelemAsync(id, ct) ?? throw new KeyNotFoundException($"Robot {id} not found");
            return new RobotResponseExtraDTO
            {
                Id = robot.Id,
                DevAlias = robot.DevAlias,
                HubId = robot.HubId,
                RobTelemetry = robot.Telemetry is null ? null :
                        new RobotTelemetryResponseDTO
                        {
                            Id = robot.Telemetry.Id,
                            RobotId = robot.Telemetry.RobotId,
                            RobotType = robot.Telemetry.DevType,
                            Status = robot.Telemetry.Status,
                            PosX = robot.Telemetry.PositionX,
                            PosY = robot.Telemetry.PositionY,
                            Battery = robot.Telemetry.BatteryLevel,
                            Speed = robot.Telemetry.Speed
                        }
                    
            };
        }

        public async Task CreateRobot(RobotRequestDTO request, Guid hubId, CancellationToken ct = default)
        {
            var entity = new RobotEntity
            {
                DevAlias = request.DevAlias,
                HubId = hubId
            };

            _robotRepository.CreateRobot(entity);
            await _robotRepository.SaveChangesAsync(ct);
        }

        public async Task UpdateRobot(Guid id, RobotUpdateDTO update, CancellationToken ct = default)
        {
            var robot = await _robotRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Robot {id} not found");
            robot.DevAlias = update.DevAlias;

            await _robotRepository.UpdateRobotData(id, robot, ct);

        }

        public async Task DeleteRobot(Guid id, CancellationToken ct = default)
        {

            var affected = await _robotRepository.DeleteRobotAsync(id, ct);
            if (affected == 0)
            {
                throw new KeyNotFoundException($"Robot {id} not found");
            }

        }
    }
}

