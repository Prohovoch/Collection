
using Collection.DTO.User;
using System.Collections.Immutable;
namespace Collection.Service.User

{
    public interface IUserService
    {
        Task<ImmutableArray<UserResponseDTO>> GetUsersResponseAsync(CancellationToken ct = default);
        Task<UserResponseDTO> GetUserById(Guid id, CancellationToken ct = default);
        Task<UserResponseHubsDTO> GetUserWithHubs(Guid id, CancellationToken ct = default);
        Task  UserCreate(UserRequestDTO creation, CancellationToken ct = default);

        Task DeleteUser(Guid id, CancellationToken ct = default);
        Task UpdateUser(Guid id, UserUpdateDTO user, CancellationToken ct = default);
        Task UpdatePatch(Guid id, UserPatchDTO patch, CancellationToken ct = default);
    }
}
