using Microsoft.EntityFrameworkCore;
using Collection.Models.DeviceTelemetry;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Collection.Сonfiguration.Entities.DeviceTelemetry
{
    public class DeviceTelemetryConfiguration : IEntityTypeConfiguration<DevTelemetryEntity>
    {
        public void Configure(EntityTypeBuilder<DevTelemetryEntity> builder)
        {
            builder.ToTable("dev_telemetry", "ethernet");
            builder.HasKey(t => t.Id);
         

            builder.Property(t => t.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(t => t.DeviceId).IsRequired().HasColumnName("device_id");
            builder.Property(t => t.DevType).HasColumnName("dev_type").HasMaxLength(50);
            builder.Property(t => t.Pressure).HasColumnName("pressure").HasPrecision(18, 4).HasColumnType("decimal");
            builder.Property(t => t.BatteryLevel).HasColumnName("battery_level").HasColumnType("int");
            builder.Property(t => t.Tempreature).HasColumnName("tempreature").HasPrecision(18, 4).HasColumnType("decimal");
            builder.Property(t => t.Status).HasColumnName("status").HasColumnType("varchar");

        }

    }
}
