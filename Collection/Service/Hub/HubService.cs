using Collection.DTO.Hub;
using Collection.Models.Hub;
using Collection.Repository.Hub;
using Collection.DTO.Robot;
using Collection.DTO.Device;


using System.Collections.Immutable;
namespace Collection.Service.Hub
{
    // Service реализует логику работы с бд, проводит создание проекций, возвращает и выдает запросы.
    // Для полноты картины можно было бы выделить маппинг в отдельную категорию папок. Но из за ограничений сделал посабление по данному поводу.
    public class HubService:IHubService
    {
        private readonly IHubRepository _hubRepository;

        public HubService(IHubRepository hubRepository)
        {
            _hubRepository = hubRepository;
        }

        public async Task<ImmutableArray<HubResponseDTO>> GetAllAsync(CancellationToken ct = default)
        {
            var hubs = await _hubRepository.GetAllAsync(ct);
            return [.. hubs.Select(h => new HubResponseDTO
            {
                Id = h.Id,
                HubAlias = h.HubAlias,
                IsActive = h.HubIsActive,
                UserId = h.UserId
            })];
        }

        public async Task<HubResponseDTO> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var hub = await _hubRepository.GetByIdAsync(id, ct) ?? throw new KeyNotFoundException($"Hub {id} not found");
            return new HubResponseDTO
            {
                Id = hub.Id,
                HubAlias = hub.HubAlias,
                IsActive = hub.HubIsActive,
                UserId = hub.UserId
            };
        }

        public async Task<HubResponseExtraDTO> GetByIdWithDevicesRobotsAsync(Guid id, CancellationToken ct = default)
        {
            var hub = await _hubRepository.GetByIdRobDevAsync(id, ct);
            if (hub is null)
                throw new KeyNotFoundException($"Hub {id} not found");

            return new HubResponseExtraDTO
            {
                Id = hub.Id,
                HubAlias = hub.HubAlias,
                IsActive = hub.HubIsActive,
                UserId = hub.UserId,
                Devices = hub.Devices?.Select(d => new DeviceResponseDTO
                {
                    Id = d.Id,
                    DevAlias = d.DevAlias,
                    HubId = d.HubId
                }).ToImmutableArray(),
                Robots = hub.Robots?.Select(r => new RobotResponseDTO
                {
                    Id = r.Id,
                    DevAlias = r.DevAlias,
                    HubId = r.HubId
                }).ToImmutableArray()
            };
        }

        public async Task CreateHub(HubRequestDTO request, Guid userId, CancellationToken ct = default)
        {
            var entity = new HubEntity
            {
                HubAlias = request.HubAlias,
                HubIsActive = request.IsActive ?? false,
                UserId = userId
            };

            _hubRepository.CreateHub(entity);
            await _hubRepository.SaveChangesAsync(ct);
        }

        public async Task UpdateHub(Guid id, HubUpdateDTO update, CancellationToken ct = default)
        {
            var hub = await _hubRepository.GetByIdAsync(id, ct) ?? throw new KeyNotFoundException($"Hub {id} not found");
            hub.HubAlias = update.HubAlias;
            hub.HubIsActive = update.IsActive;

            
               

            await _hubRepository.UpdateHubData(id, hub, ct);

        }

        public async Task DeleteHub(Guid id, CancellationToken ct = default)
        {

            var affected = await _hubRepository.DeleteHubAsync(id, ct);
            if (affected == 0)
            {
                throw new KeyNotFoundException(($"Hub {id} not found"));
            }

        }
    }
}
    