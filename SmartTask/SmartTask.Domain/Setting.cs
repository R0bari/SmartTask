namespace SmartTask.Domain;

public record Setting(int Id, SettingType Type, string Value, User User);

public enum SettingType
{
    FontSize,
    FontColor,
    BackgroundColor
}