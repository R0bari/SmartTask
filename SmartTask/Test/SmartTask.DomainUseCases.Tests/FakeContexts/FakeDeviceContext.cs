using SmartTask.Domain;
using SmartTask.DomainUseCases.Contexts;
using Task = System.Threading.Tasks.Task;

namespace SmartTask.DomainUseCases.Tests.FakeContexts;

public class FakeDeviceContext : IDeviceContext
{
    private readonly List<Device> _devices = new List<Device>();

    public Task<Device> GetDeviceById(Guid id) =>
        Task.Run(() => _devices.FirstOrDefault(d => d.Id == id) ?? Device.Empty);

    public Task<Guid> CreateDevice(Device newDevice)
    {
        var addedDevice = newDevice with {Id = Guid.NewGuid()};
        _devices.Add(addedDevice);
        return Task.FromResult(addedDevice.Id);
    }

    public Task<Device> ChangeDevice(Guid id, Device device)
    {
        var foundDevice = _devices.FirstOrDefault(d => d.Id == id) ?? Device.Empty;
        if (foundDevice == Device.Empty)
        {
            return Task.FromResult(Device.Empty);
        }

        foundDevice = device;

        return Task.FromResult(foundDevice);
    }

    public Task<int> DeleteDevice(Guid id)
    {
        var found = _devices.FirstOrDefault(d => d.Id == id) ?? Device.Empty;
        return found == Device.Empty
            ? Task.FromResult(-1)
            : Task.FromResult(_devices.RemoveAll(d => d.Id == id));
    }
}
