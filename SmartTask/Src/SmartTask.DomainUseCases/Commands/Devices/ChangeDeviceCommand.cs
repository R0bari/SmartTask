using SmartTask.Domain;

namespace SmartTask.DomainUseCases.Commands.Devices;

public class ChangeDeviceCommand
{
    private readonly ITaskContext _context;

    public ChangeDeviceCommand(ITaskContext context) => _context = context;

    public async Task<Device> ExecuteAsync(Guid deviceId, Device changedDevice) =>
        throw new NotImplementedException();
}