namespace SmartTask.DomainUseCases.Commands.Tasks;

public class DeleteTaskCommand
{
    private readonly ITaskContext _context;

    public DeleteTaskCommand(ITaskContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync(TaskContextSpecification specification) =>
        throw new NotImplementedException();
}