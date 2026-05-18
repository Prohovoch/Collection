using Collection.DTO.User;
using Collection.Models.User;
using Collection.Repository.User;
using Collection.DTO.Hub;
using System.Collections.Immutable;

namespace Collection.Service.User
{
    // Service реализует логику работы с бд, проводит создание проекций, возвращает и выдает запросы.
    // Для полноты картины можно было бы выделить маппинг в отдельную категорию папок. Но из за ограничений сделал посабление по данному поводу.
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        // GET ALL
        public async Task<ImmutableArray<UserResponseDTO>> GetUsersResponseAsync(CancellationToken ct = default)
        {
            var users = await _userRepository.GetAllAsync(ct);

            return [.. users.Select(u => new UserResponseDTO
            {
                Id = u.Id,
                Name = u.Name,
                Surname = u.Surname,
                Age = u.Age
            })];
        }

        // GET BY ID
        public async Task<UserResponseDTO> GetUserById(Guid id, CancellationToken ct = default)
        {
            var user = await _userRepository.GetByIdAsync(id, ct) ?? throw new KeyNotFoundException($"User {id} not found");
            return new UserResponseDTO
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Age = user.Age
            };
        }

        // GET WITH HUBS
        public async Task<UserResponseHubsDTO> GetUserWithHubs(Guid id, CancellationToken ct = default)
        {
            var user = await _userRepository.GetByIdWithHubsAsync(id, ct) ?? throw new KeyNotFoundException($"User {id} not found");
            return new UserResponseHubsDTO
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Age = user.Age,
                Hubs = user.Hubs?.Select(h => new HubResponseDTO
                {
                    Id = h.Id,
                    HubAlias = h.HubAlias,
                    IsActive = h.HubIsActive
                }).ToImmutableArray()
            };
        }

        // CREATE
        public async Task  UserCreate(UserRequestDTO creation, CancellationToken ct = default)
        {
            var entity = new UserEntity
            {
                Name = creation.Name,
                Surname = creation.Surname,
                Age = creation.Age
            };

            _userRepository.CreateUser(entity);
            await _userRepository.SaveChangesAsync(ct);

        }

        // DELETE
        public async Task DeleteUser(Guid id, CancellationToken ct = default)
        {
            var affected = await _userRepository.DeleteUserAsync(id, ct);

            if (affected == 0)
                throw new KeyNotFoundException($"User {id} not found");
        }

        // PUT — полное обновление
        public async Task UpdateUser(Guid Id, UserUpdateDTO dto, CancellationToken ct = default)
        {
            var user = await _userRepository.GetByIdAsync(Id, ct) ?? throw new KeyNotFoundException($"User {Id} not found");
            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.Age = dto.Age;

            await _userRepository.UpdateUserData(Id, user, ct);

        }

        // PATCH — частичное обновление
        public async Task UpdatePatch(Guid id, UserPatchDTO patch, CancellationToken ct = default)
        {
            var user = await _userRepository.GetByIdAsync(id, ct) ?? throw new KeyNotFoundException($"User {id} not found");
            if (patch.Name is not null)
                user.Name = patch.Name;

            if (patch.Surname is not null)
                user.Surname = patch.Surname;

            if (patch.Age is not null)
                user.Age = patch.Age;

            await _userRepository.UpdateUserData(id, user, ct);

        }
    }
}
