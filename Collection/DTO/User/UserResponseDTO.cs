
using Collection.DTO.Hub;
using System.Collections.Immutable;
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
        public ImmutableArray<HubResponseDTO>? Hubs { get; init; }
    }

    }

