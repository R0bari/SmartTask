using SmartTask.Domain;

namespace SmartTask.DomainUseCases.Contexts;

public record SettingContextSpecification
{
    public Guid UserId { get; init; } = Guid.Empty;
    public string Name { get; init; } = "";
}
public interface ISettingContext
{
    /// <summary>
    /// Get settings by userId, name
    /// </summary>
    /// <param name="specification"></param>
    /// <returns></returns>
    List<Device> GetSettings(SettingContextSpecification specification);

    /// <summary>
    /// Create setting
    /// </summary>
    /// <param name="device"></param>
    /// <returns></returns>
    Guid CreateSetting(Device device);

    /// <summary>
    /// Change setting name
    /// </summary>
    /// <param name="id"></param>
    /// <param name="device"></param>
    /// <returns></returns>
    Device ChangeSetting(Guid id, Device device);

    /// <summary>
    /// Delete setting by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    int DeleteSetting(Guid id);
}
