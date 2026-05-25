namespace ComputerComponentManagementSystem.DTO;

public class Details
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    public List<ComponentEntry> Components { get; set; } = new();
}

public class ComponentEntry
{
    public int Amount { get; set; }
    public ComponentInfo Component { get; set; } = null!;
}

public class ComponentInfo
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public ManufacturerInfo Manufacturer { get; set; } = null!;
    public TypeInfo Type { get; set; } = null!;
}

public class ManufacturerInfo
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public DateTime FoundationDate { get; set; }
}

public class TypeInfo
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = null!;
    public string Name { get; set; } = null!;
}