using ComputerComponentManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerComponentManagementSystem.Data;

public class ComponentConf : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> entity)
    {
        entity.ToTable("Components");
        entity.HasKey(c => c.Code);

        entity.Property(c => c.Code)
              .HasColumnType("char(10)")
              .HasMaxLength(10)
              .IsRequired();

        entity.Property(c => c.Name)
              .HasMaxLength(300)
              .IsRequired();

        entity.Property(c => c.Description)
              .HasColumnType("nvarchar(max)");

        entity.HasOne(c => c.ComponentManufacturer)
              .WithMany(m => m.Components)
              .HasForeignKey(c => c.ComponentManufacturersId)
              .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(c => c.ComponentType)
              .WithMany(t => t.Components)
              .HasForeignKey(c => c.ComponentTypesId)
              .OnDelete(DeleteBehavior.Restrict);

        entity.HasData(
            new Component
            {
                Code = "CPU0000001",
                Name = "Ryzen 7 7800X3D",
                Description = "8-core gaming processor",
                ComponentManufacturersId = 1,
                ComponentTypesId = 1
            },
            new Component
            {
                Code = "GPU0000001",
                Name = "RTX 4080 Super",
                Description = "High-end gaming graphics card",
                ComponentManufacturersId = 2,
                ComponentTypesId = 2
            },
            new Component
            {
                Code = "RAM0000001",
                Name = "Corsair Vengeance DDR5 16GB",
                Description = "DDR5 RAM module 16GB",
                ComponentManufacturersId = 3,
                ComponentTypesId = 3
            }
        );
    }
}
