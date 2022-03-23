using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTask.Domain;

public record User
{
    public Guid Id { get; }
    public string Email { get; }
    public DateTime CreateDate { get; }
    public List<Task> Tasks { get; }
    public List<Device> Devices { get; }
    public List<Setting> Settings { get; }
    
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

