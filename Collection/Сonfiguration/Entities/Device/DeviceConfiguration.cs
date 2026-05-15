using Collection.Models.Device;
using Collection.Models.DeviceTelemetry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collection.Сonfiguration.Entities.Device
{
    public class DeviceConfiguration : IEntityTypeConfiguration<DeviceEntity>
    {
        public void Configure(EntityTypeBuilder<DeviceEntity> builder)
        {

            builder.ToTable("devices", "ethernet");
            builder.HasKey(d => d.Id);
            builder.HasOne(t => t.Telemetry)
                .WithOne(t => t.Device)
                .HasForeignKey<DevTelemetryEntity>(t => t.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(d => d.HubId).IsRequired().HasColumnName("hub_id");
            builder.Property(d => d.DevAlias).IsRequired().HasMaxLength(50).HasColumnName("dev_alias");




        }
    }
}
