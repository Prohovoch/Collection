using Collection.Models.Robot;
using Collection.Models.RobotTelemetry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collection.Сonfiguration.Entities.Robot
{
    public class RobotConfiguration:IEntityTypeConfiguration<RobotEntity>
    {
        public void Configure(EntityTypeBuilder<RobotEntity> builder)
        {
            builder.ToTable("robots", "ethernet");
            builder.HasKey(r => r.Id);
            builder.HasOne(t => t.Telemetry)
                .WithOne(t => t.Robot) // 1 : 1
                .HasForeignKey<RobTelemetryEntity>(t => t.RobotId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Property(r => r.DevAlias).IsRequired().HasMaxLength(50).HasColumnName("dev_alias");
            builder.Property(r => r.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(r => r.HubId).IsRequired().HasColumnName("hub_id");

        }
    }
}
