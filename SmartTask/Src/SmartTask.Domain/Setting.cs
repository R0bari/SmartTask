using System;

namespace SmartTask.Domain;

public record Setting
{
    public Guid Id { get; }
    public SettingType Type { get; }
    public string Value { get; }
    public User User { get; }
    
    public Setting(SettingType type, string value, User user)
    {
        Id = Guid.NewGuid();
        Type = type;
        Value = value;
        User = user;
    }
}

public enum SettingType
{
    FontSize,
    FontColor,
    BackgroundColor
}