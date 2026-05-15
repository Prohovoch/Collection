using Collection.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collection.Сonfiguration.Entities.User
{
    /*
     * Данная функция нужна для конфигурирования проекции таблиц в ORM. Настройка ключей, обозначений полей происходят тут.
     * 
     * 
     */
    public class UserConfiguration:IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder) {
            builder.ToTable("users", "ethernet");
            builder.HasKey(u => u.Id);
            builder.HasMany(u => u.Hubs)
                .WithOne(h => h.User)
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            // Настраиваем свойства.    
            builder.Property(u => u.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(u => u.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
            builder.Property(u => u.Surname).IsRequired().HasColumnName("Surname").HasMaxLength(50);
            builder.Property(u => u.Age).HasColumnName("age");

        }
    }
}
