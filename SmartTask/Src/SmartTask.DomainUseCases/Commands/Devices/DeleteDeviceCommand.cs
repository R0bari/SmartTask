using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Commands.Devices;

public class DeleteDeviceCommand
{
    private readonly IDeviceContext _context;

    public DeleteDeviceCommand(IDeviceContext context) => _context = context;

    public async Task<int> ExecuteAsync(Guid id) =>
        await _context.DeleteDevice(id);
}