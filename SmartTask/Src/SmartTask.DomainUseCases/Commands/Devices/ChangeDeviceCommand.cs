using SmartTask.Domain;
using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Commands.Devices;

public class ChangeDeviceCommand
{
    private readonly IDeviceContext _context;

    public ChangeDeviceCommand(IDeviceContext context) => _context = context;

    public async Task<Device> ExecuteAsync(Guid deviceId, Device changedDevice) =>
        throw new NotImplementedException();
}
