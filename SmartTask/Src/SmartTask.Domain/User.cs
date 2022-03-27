using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTask.Domain;

public record User
{
    public Guid Id { get; init; }
    public string Email { get; init; }
    public DateTime CreateDate { get; init; }
    public List<Task> Tasks { get; init; }
    public List<Device> Devices { get; init; }
    public List<Setting> Settings { get; init; }

    public static User Empty =>
        new User(
            "",
            DateTime.MinValue,
            new List<Task>(),
            new List<Device>(),
            new List<Setting>());
    
    public User(
        string email,
        DateTime createDate,
        List<Task> tasks,
        List<Device> devices,
        List<Setting> settings)
    {
        Id = Guid.NewGuid();
        Email = email;
        CreateDate = createDate;
        Tasks = tasks;
        Devices = devices;
        Settings = settings;
    }
};
