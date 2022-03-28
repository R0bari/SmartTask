using SmartTask.Domain;

namespace SmartTask.DomainUseCases.Contexts;

public record DeviceContextSpecification
{
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
    Task<Device> GetDeviceById(Guid id);

    Task<Guid> CreateDevice(Device device);

    /// <summary>
    /// Change device name, address
    /// </summary>
    /// <param name="id"></param>
    /// <param name="device"></param>
    /// <returns></returns>
    Task<Device> ChangeDevice(Guid id, Device device);

    /// <summary>
    /// Delete device by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<int> DeleteDevice(Guid id);
}
