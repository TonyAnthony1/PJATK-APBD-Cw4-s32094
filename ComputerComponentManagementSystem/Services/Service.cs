using ComputerComponentManagementSystem.Data;
using ComputerComponentManagementSystem.DTO;
using ComputerComponentManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerComponentManagementSystem.Services;

public class Service : IService
{
    private readonly AppDbContext _db;

    public Service(AppDbContext db) => _db = db;

    public async Task<IEnumerable<ListItem>> GetAllAsync()
    {
        return await _db.PCs
            .AsNoTracking()
            .Select(p => new ListItem
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            })
            .ToListAsync();
    }

    public async Task<Details?> GetWithComponentsAsync(int id)
    {
        return await _db.PCs
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => new Details
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock,
                Components = p.PCComponents.Select(link => new ComponentEntry
                {
                    Amount = link.Amount,
                    Component = new ComponentInfo
                    {
                        Code = link.Component.Code,
                        Name = link.Component.Name,
                        Description = link.Component.Description,
                        Manufacturer = new ManufacturerInfo
                        {
                            Id = link.Component.ComponentManufacturer.Id,
                            Abbreviation = link.Component.ComponentManufacturer.Abbreviation,
                            FullName = link.Component.ComponentManufacturer.FullName,
                            FoundationDate = link.Component.ComponentManufacturer.FoundationDate
                        },
                        Type = new TypeInfo
                        {
                            Id = link.Component.ComponentType.Id,
                            Abbreviation = link.Component.ComponentType.Abbreviation,
                            Name = link.Component.ComponentType.Name
                        }
                    }
                }).ToList()
            })
            .FirstOrDefaultAsync();
    }

    public async Task<Response> CreateAsync(CreateUpdate dto)
    {
        var pc = new PC
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        _db.PCs.Add(pc);
        await _db.SaveChangesAsync();

        return new Response
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<bool> UpdateAsync(int id, CreateUpdate dto)
    {
        var pc = await _db.PCs.FindAsync(id);
        if (pc is null) return false;

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pc = await _db.PCs.FindAsync(id);
        if (pc is null) return false;

        _db.PCs.Remove(pc);
        await _db.SaveChangesAsync();
        return true;
    }
}
