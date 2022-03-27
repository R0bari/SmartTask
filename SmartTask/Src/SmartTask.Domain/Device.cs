using System;

namespace SmartTask.Domain;

public record Device
{
    public Guid Id { get; init; } = Guid.Empty;
    public string Name { get; init; } = "";
    public string Address { get; init; } = "";

    public static Device Empty => new Device
    {
        Id = Guid.Empty,
        Name = "",
        Address = ""
    };

    public Device() { }
    public Device(string name, string address)
    {
        Id = Guid.NewGuid();
        Name = name;
        Address = address;
    }
};