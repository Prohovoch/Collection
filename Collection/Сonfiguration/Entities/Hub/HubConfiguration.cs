using Collection.Models.Hub;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collection.Сonfiguration.Entities.Hub
{
    /*
     * Настройка билдера и свойств для проекции таблицы  hub
     * 
     */
    public class HubConfiguration : IEntityTypeConfiguration<HubEntity>
    {
        public void Configure(EntityTypeBuilder<HubEntity> builder)
        {
            builder.ToTable("hubs", "ethernet"); // schema
            builder.HasKey(h => h.Id);
            builder.HasMany(d => d.Devices)
                .WithOne(d => d.Hub)
                .HasForeignKey(d => d.HubId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Robots)
                .WithOne(r => r.Hub)
                .HasForeignKey(r => r.HubId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(h => h.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(h => h.UserId).IsRequired().HasColumnName("user_id");

            builder.Property(h => h.HubAlias).HasMaxLength(50).HasColumnName("hub_alias");

            builder.Property(h => h.HubIsActive).HasColumnName("hub_isactive");
        }
    }
    
}
