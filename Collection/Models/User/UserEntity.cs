using Collection.Models.Hub;
namespace Collection.Models.User
{

    /*
     *  Класс сущности
     *  Имеет связь 1 ко многим с хабами, представлена в виде списка. ака навигационная связь.
     */
    public class UserEntity
    {
        // RFC 9562
        public Guid Id { get; set; } = Guid.CreateVersion7();


        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int? Age { get; set; }

        // 1 : m relations
        public List<HubEntity> Hubs { get; } = new List<HubEntity>();

    }
}

