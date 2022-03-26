using SmartTask.Domain;

namespace SmartTask.DomainUseCases.Contexts;

public record DeviceContextSpecification
{
    public Guid UserId { get; init; } = Guid.Empty;
    public string Name { get; init; } = "";
    public string Address { get; init; } = "";
}
public interface IDeviceContext
{
    /// <summary>
    /// Get devices by userId, name, address
    /// </summary>
    /// <param name="specification"></param>
    /// <returns></returns>
    List<Device> GetDevices(DeviceContextSpecification specification);

    /// <summary>
    /// Create device
    /// </summary>
    /// <param name="device"></param>
    /// <returns></returns>
    Guid CreateDevice(Device device);

    /// <summary>
    /// Change device name, address
    /// </summary>
    /// <param name="id"></param>
    /// <param name="device"></param>
    /// <returns></returns>
    Device ChangeDevice(Guid id, Device device);

    /// <summary>
    /// Delete device by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    int DeleteDevice(Guid id);
}
