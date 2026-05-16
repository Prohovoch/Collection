using Collection.Models.Robot;
using IoT.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Collection.Repository.Robot
{
    public class RobotRepositrory : IRobotRepository
    {
        private readonly ApplicationDbContext _context;

        public RobotRepositrory(ApplicationDbContext Context)
        {
            _context = Context;

        }

        public async Task<IReadOnlyCollection<RobotEntity>> GetAllAsync(CancellationToken ct = default) =>
           await _context.Robots.AsNoTracking().ToListAsync(ct);


        public async Task<RobotEntity?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
            await _context.Robots.FirstOrDefaultAsync(r => r.Id == id, ct);


        public async Task<RobotEntity?> GetByIdTelemAsync(Guid id, CancellationToken ct = default) =>
            await _context.Robots.Include(r => r.Telemetry).FirstOrDefaultAsync(r => r.Id == id, ct);

        public async Task<int> DeleteRobotAsync(Guid id, CancellationToken ct = default) =>
            await _context.Robots.Where(r => r.Id == id).ExecuteDeleteAsync(ct);
        public void CreateRobot(RobotEntity robot)
        {
            _context.Robots.Add(robot);
        }

        public async Task UpdateRobotData(Guid id, RobotEntity robot, CancellationToken ct = default) =>
            await _context.Devices.Where(r => r.Id == id).ExecuteUpdateAsync(r => r.SetProperty(r => r.DevAlias, r => robot.DevAlias), ct);
        public async Task SaveChangesAsync(CancellationToken ct = default) => await _context.SaveChangesAsync(ct);

    }
}
