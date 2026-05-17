using Collection.Models.Device;
using Collection.Models.DeviceTelemetry;
using Collection.Models.Hub;
using Collection.Models.Robot;
using Collection.Models.RobotTelemetry;
using Collection.Models.User;
using Microsoft.EntityFrameworkCore;
namespace Collection.Persistence

{
    public class ApplicationDbContext : DbContext
    // Описание наших таблиц в контексте EF Core
    {
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<HubEntity> Hubs => Set<HubEntity>();
        public DbSet<DeviceEntity> Devices => Set<DeviceEntity>();
        public DbSet<RobotEntity> Robots => Set<RobotEntity>();
        public DbSet<DevTelemetryEntity> DeviceTelemetries => Set<DevTelemetryEntity>();
        public DbSet<RobTelemetryEntity> RobotTelemetries => Set<RobTelemetryEntity>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Используем ассемблер для поиска нашего контекста в проекте, хорошая практика.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);



        }
    }
}