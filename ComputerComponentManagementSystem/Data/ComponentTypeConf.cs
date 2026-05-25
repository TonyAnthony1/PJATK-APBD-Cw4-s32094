using ComputerComponentManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerComponentManagementSystem.Data;

public class ComponentTypeConf : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> entity)
    {
        entity.ToTable("ComponentTypes");
        entity.HasKey(t => t.Id);

        entity.Property(t => t.Abbreviation)
            .HasMaxLength(30)
            .IsRequired();

        entity.Property(t => t.Name)
            .HasMaxLength(150)
            .IsRequired();

        entity.HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Processor" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Memory" }
        );
    }
}