using System.Collections.Immutable;
using Collection.DTO.Hub;
namespace Collection.Service.Hub
{
    public interface IHubService
    {
        Task<ImmutableArray<HubResponseDTO>> GetAllAsync(CancellationToken ct = default);
        Task<HubResponseDTO> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<HubResponseExtraDTO> GetByIdWithDevicesRobotsAsync(Guid id, CancellationToken ct = default);
        Task CreateHub(HubRequestDTO request, Guid userId, CancellationToken ct = default);
        Task UpdateHub(Guid id, HubUpdateDTO update, CancellationToken ct = default);
        Task DeleteHub(Guid id, CancellationToken ct = default);
    }
}

