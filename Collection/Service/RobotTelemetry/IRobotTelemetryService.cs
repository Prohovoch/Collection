using Collection.DTO.RobotTelemetry;
using System.Collections.Immutable;

namespace Collection.Service.RobotTelemetry
{
    public interface IRobotTelemetryService
    {
        Task<ImmutableArray<RobotTelemetryResponseDTO>> GetAllAsync(CancellationToken ct = default);
        Task<RobotTelemetryResponseDTO> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task CreateAsync(RobotTelemetryRequestDTO request, Guid robotId, CancellationToken ct = default);
        Task UpdateAsync(Guid id, RobotTelemetryUpdateDTO update, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
