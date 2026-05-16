using Collection.Models.User;

namespace Collection.Repository.User
{
    // Интерфейс, описывающий контракт исполнение задач репозиторием
    public interface IUserRepository
    {
        Task<IReadOnlyCollection<UserEntity>> GetAllAsync(CancellationToken ct = default);
        Task<UserEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<UserEntity?> GetByIdWithHubsAsync(Guid id, CancellationToken ct = default);
        Task<int> DeleteUserAsync(Guid id, CancellationToken ct = default);
        public void CreateUser(UserEntity user);
        Task UpdateUserData(Guid id, UserEntity user, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
