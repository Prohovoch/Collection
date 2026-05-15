using Collection.Models.User;

namespace Collection.Models.Hub
{
    public class HubEntity
    {

        /*
         * Сущность имеет внешний ключ на пользователя, а также навигационные свойства
         */
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public Guid UserId { get; set; }
        public bool HubIsActive { get; set; }

        public string? HubAlias { get; set; }
        
        // Навигационное свойство на родителя
        public UserEntity User { get; set; } = null!;

        /*
         * 1 : m relations
         * 1 : m relations
         */
        public List<DeviceEntity> Devices { get; } = new List<DeviceEntity>();
        public List<RobotEntity> Robots { get; } = new List<RobotEntity>();
    }
}
