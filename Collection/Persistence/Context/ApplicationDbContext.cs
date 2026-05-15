using Collection.Models.Device;
using Collection.Models.DeviceTelemetry;
using Collection.Models.Hub;
using Collection.Models.Robot;
using Collection.Models.RobotTelemetry;
using Collection.Models.User;
using Microsoft.EntityFrameworkCore;
namespace IoT.Persistence

{
    public class ApplicationDbContext : DbContext

    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<HubEntity> Hubs { get; set; }
        public DbSet<DeviceEntity> Devices { get; set; }
        public DbSet<RobotEntity> Robots { get; set; }
        public DbSet<DevTelemetryEntity> DeviceTelemetries { get; set; }
        public DbSet<RobTelemetryEntity> RobotTelemetries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);



        }
    }
}