using System;

namespace SmartTask.Domain;

public record Device
{
    public Guid Id { get; }
    public string Name { get; }
    public string Address { get; }
    
    public Device(string name, string address)
    {
        Id = Guid.NewGuid();
        Name = name;
        Address = address;
    }
};