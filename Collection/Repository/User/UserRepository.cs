using Collection.Models.User;
using IoT.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Collection.Repository.User
{

    // Реализация репозитория с использованием DI, LINQ. CRUD операции.
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _Context;
        public UserRepository(ApplicationDbContext context)
        {

            _Context = context;

        }

        public async Task<UserEntity?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
            await _Context.Users.FirstOrDefaultAsync(u => u.Id == id, ct);



        public async Task<UserEntity?> GetByIdWithHubsAsync(Guid id, CancellationToken ct = default) =>
            await _Context.Users
            .Include(u => u.Hubs)
            .FirstOrDefaultAsync(u => u.Id == id, ct);
        public async Task<IReadOnlyList<UserEntity>> GetAllAsync(CancellationToken ct = default) =>
            await _Context.Users.AsNoTracking().ToListAsync(ct);


        public void CreateUser(UserEntity user)
        {
            // -> in memory, no io
            _Context.Users.Add(user);


        }


        public async Task UpdateUserData(Guid id, UserEntity user, CancellationToken ct = default) =>
            await _Context.Users.Where(u => u.Id == id).ExecuteUpdateAsync(u => u.SetProperty(u => u.Name, u => user.Name)
            .SetProperty(u => u.Surname, u => user.Surname)
            .SetProperty(u => u.Age, u => user.Age), ct);


        public async Task<int> DeleteUserAsync(Guid id, CancellationToken ct = default) =>
            await _Context.Users.Where(u => u.Id == id).ExecuteDeleteAsync(ct);

        public async Task SaveChangesAsync(CancellationToken ct = default) =>
            await _Context.SaveChangesAsync(ct);
    }
}
