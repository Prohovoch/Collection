using System.Collections.Immutable;
using Collection.DTO.Hub;
namespace Collection.DTO.User
{
    public class UserResponseDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
        public string Surname { get; init; } = null!;

        public int? Age { get; init; }
    }

    public class UserResponseHubsDTO : UserResponseDTO
    {
        public IReadOnlyList<HubResponseDTO>? Hubs { get; init; }
    }

    }

