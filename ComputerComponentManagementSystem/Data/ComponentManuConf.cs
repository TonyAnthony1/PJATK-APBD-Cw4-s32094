using ComputerComponentManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerComponentManagementSystem.Data;

public class ComponentManuConf : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> entity)
    {
        entity.ToTable("ComponentManufacturers");
        entity.HasKey(m => m.Id);

        entity.Property(m => m.Abbreviation)
            .HasMaxLength(30)
            .IsRequired();

        entity.Property(m => m.FullName)
            .HasMaxLength(300)
            .IsRequired();

        entity.Property(m => m.FoundationDate)
            .HasColumnType("date");

        entity.HasData(
            new ComponentManufacturer
            {
                Id = 1,
                Abbreviation = "AMD",
                FullName = "Advanced Micro Devices",
                FoundationDate = new DateTime(1969, 5, 1)
            },
            new ComponentManufacturer
            {
                Id = 2,
                Abbreviation = "NV",
                FullName = "NVIDIA Corporation",
                FoundationDate = new DateTime(1993, 4, 5)
            },
            new ComponentManufacturer
            {
                Id = 3,
                Abbreviation = "COR",
                FullName = "Corsair Gaming Inc.",
                FoundationDate = new DateTime(1994, 1, 1)
            }
        );
    }
}