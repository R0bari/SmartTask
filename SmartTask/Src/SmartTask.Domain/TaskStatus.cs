using System;

namespace SmartTask.Domain;

public record TaskStatus
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public static TaskStatus Empty => new TaskStatus(Guid.Empty, "None");
    
    public TaskStatus() { }
    public TaskStatus(Guid id, string name) => (Id, Name) = (id, name);
}
