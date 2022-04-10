using System;

namespace SmartTask.Domain;

public record Category
{
    public Guid Id { get; init; } = Guid.Empty;
    public string Name { get; init; } = "";

    public static Category Empty => new Category
    {
        Id = Guid.Empty,
        Name = ""
    };

    public Category()
    {
    }

    public Category(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
