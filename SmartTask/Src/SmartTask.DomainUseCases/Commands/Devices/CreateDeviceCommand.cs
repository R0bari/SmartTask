using SmartTask.Domain;
using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Commands.Devices;

public class CreateDeviceCommand
{
    private readonly IDeviceContext _context;

    public CreateDeviceCommand(IDeviceContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(Device newDevice) =>
        await _context.CreateDevice(newDevice);
}
