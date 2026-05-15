using Microsoft.EntityFrameworkCore;

using Collection.Models.RobotTelemetry;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Collection.Сonfiguration.Entities.RobotTelemetry
{
    public class RobotTelemetryConfiguration : IEntityTypeConfiguration<RobTelemetryEntity>
    {
        // Данная таблица является зависимой и не имеет никаких дочерних связей, кроме родительской. Согласно документации
        // мы можем делать связь 1 к 1 как с дочерней в родительскую, так и с родительской в дочернюю, но не с двух сторон одновременно.
        // Поэтому 1 к 1 мы настроили с родителя RobotEntity.
        public void Configure(EntityTypeBuilder<RobTelemetryEntity> builder)
        {
            builder.ToTable("rob_telemetry", "ethernet");
            builder.HasKey(rt => rt.Id);

            builder.Property(rt => rt.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(rt => rt.RobotId).IsRequired().HasColumnName("robot_id");
            builder.Property(rt => rt.DevType).HasColumnName("robot_type").HasMaxLength(50).HasColumnType("varchar");
            builder.Property(rt => rt.Status).HasColumnName("status").HasColumnType("varchar").HasMaxLength(50);
            builder.Property(rt => rt.BatteryLevel).HasColumnName("battery_level").HasColumnType("int");
            builder.Property(rt => rt.Speed).HasColumnType("decimal").HasPrecision(18, 4).HasColumnName("speed");
            builder.Property(rt => rt.PositionX).HasColumnName("position_x").HasColumnType("decimal").HasPrecision(18, 4);
            builder.Property(rt => rt.PositionY).HasPrecision(18, 4).HasColumnName("position_y").HasColumnType("decimal");

        }
    }
}
