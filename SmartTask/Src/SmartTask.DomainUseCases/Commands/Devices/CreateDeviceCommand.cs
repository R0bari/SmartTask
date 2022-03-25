namespace SmartTask.DomainUseCases.Commands.Devices;

public class CreateDeviceCommand
{
    private readonly ITaskContext _context;

    public CreateDeviceCommand(ITaskContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync() =>
        throw new NotImplementedException();
}