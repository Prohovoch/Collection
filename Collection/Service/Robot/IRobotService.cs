using System.Collections.Immutable;
using Collection.DTO.Robot;
namespace Collection.Service.Robot
{
    public interface IRobotService
    {
        Task<ImmutableArray<RobotResponseDTO>> GetAllAsync(CancellationToken ct = default);
        Task<RobotResponseDTO> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<RobotResponseExtraDTO> GetByIdWithTelemAsync(Guid id, CancellationToken ct = default);
        Task CreateRobot(RobotRequestDTO request, Guid hubId, CancellationToken ct = default);
        Task UpdateRobot(Guid id, RobotUpdateDTO update, CancellationToken ct = default);
        Task DeleteRobot(Guid id, CancellationToken ct = default);
    }
}
