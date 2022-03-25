namespace SmartTask.DomainUseCases.Commands.Tasks;

public class CreateTaskCommand
{
    private readonly ITaskContext _context;

    public CreateTaskCommand(ITaskContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync(TaskContextSpecification specification) =>
        throw new NotImplementedException();
}