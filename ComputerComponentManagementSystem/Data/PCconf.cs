using ComputerComponentManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerComponentManagementSystem.Data;

public class PCconf : IEntityTypeConfiguration<PC>
{
    public void Configure(EntityTypeBuilder<PC> entity)
    {
        entity.ToTable("PCs");
        entity.HasKey(p => p.Id);

        entity.Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        entity.Property(p => p.Weight)
            .HasColumnType("float(5)");

        entity.Property(p => p.Warranty)
            .IsRequired();

        entity.Property(p => p.CreatedAt)
            .HasColumnType("datetime");

        entity.Property(p => p.Stock)
            .IsRequired();

        entity.HasData(
            new PC
            {
                Id = 1,
                Name = "Gaming Beast X",
                Weight = 12.5,
                Warranty = 36,
                CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0),
                Stock = 5
            },
            new PC
            {
                Id = 2,
                Name = "Office Mini Pro",
                Weight = 4.2,
                Warranty = 24,
                CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0),
                Stock = 12
            },
            new PC
            {
                Id = 3,
                Name = "Workstation Pro 5000",
                Weight = 9.8,
                Warranty = 48,
                CreatedAt = new DateTime(2026, 3, 10, 11, 15, 0),
                Stock = 3
            }
        );
    }
}