using System;

namespace SmartTask.Domain;

public record TaskPriority
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public static TaskPriority Empty => new TaskPriority(Guid.Empty, "None");
    
    public TaskPriority() { }
    public TaskPriority(Guid id, string name) => (Id, Name) = (id, name);
}
