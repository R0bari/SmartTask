namespace SmartTask.DomainUseCases.Commands.Devices;

public class ChangeDeviceCommand
{
    private readonly ITaskContext _context;

    public ChangeDeviceCommand(ITaskContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync() =>
        throw new NotImplementedException();
}