namespace SmartTask.DomainUseCases.Commands.Tasks;

public class ChangeTaskCommand
{
    private readonly ITaskContext _context;

    public ChangeTaskCommand(ITaskContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync(TaskContextSpecification specification) =>
        throw new NotImplementedException();
}