using Collection.Models.Robot;

namespace Collection.Repository.Robot
{
    public interface IRobotRepository
    {
        Task<IReadOnlyCollection<RobotEntity>> GetAllAsync(CancellationToken ct = default);
        Task<RobotEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
        
        Task<RobotEntity?> GetByIdTelemAsync(Guid id, CancellationToken ct = default);
        Task<int> DeleteRobotAsync(Guid id, CancellationToken ct = default);
        public void CreateRobot(RobotEntity robot);
        Task UpdateRobotData(Guid id, RobotEntity robot, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
