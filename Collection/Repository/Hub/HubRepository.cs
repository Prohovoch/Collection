using Collection.Models.Hub;
using IoT.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Collection.Repository.Hub
{
    public class HubRepository : IHubRepository
    {
        private readonly ApplicationDbContext _context;

        public HubRepository(ApplicationDbContext Context)
        {
            _context = Context;
        }

        public async Task<HubEntity?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
           await _context.Hubs.FirstOrDefaultAsync(h => h.Id == id, ct);

        // Большой запрос, делим пополам
        public async Task<HubEntity?> GetByIdRobDevAsync(Guid id, CancellationToken ct = default) =>
            await _context.Hubs
            .Include(h => h.Devices)
            .Include(h => h.Robots)
            .AsSplitQuery()
            .FirstOrDefaultAsync(h => h.Id == id, ct);

        public async Task<IReadOnlyCollection<HubEntity>> GetAllAsync(CancellationToken ct = default) =>
            await _context.Hubs.AsNoTracking().ToListAsync(ct);


        public void CreateHub(HubEntity hub)
        {
            // -> in memory request
            _context.Hubs.Add(hub);


        }


        public async Task UpdateHubData(Guid id, HubEntity hub, CancellationToken ct = default) =>
            await _context.Hubs.Where(h => h.Id == id).ExecuteUpdateAsync(h => h.SetProperty(h => h.HubIsActive, h => hub.HubIsActive)
            .SetProperty(h => h.HubAlias, h => hub.HubAlias), ct);




        public async Task<int> DeleteHubAsync(Guid id, CancellationToken ct = default) =>
            await _context.Hubs.Where(h => h.Id == id).ExecuteDeleteAsync(ct);

        public async Task SaveChangesAsync(CancellationToken ct = default) =>
            await _context.SaveChangesAsync(ct);
    }
}

