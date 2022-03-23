using System;

namespace SmartTask.Domain;

public record Setting
{
    public Guid Id { get; }
    public SettingType Type { get; }
    public string Value { get; }
    
    public Setting(SettingType type, string value)
    {
        Id = Guid.NewGuid();
        Type = type;
        Value = value;
    }
}

public enum SettingType
{
    FontSize,
    FontColor,
    BackgroundColor
}