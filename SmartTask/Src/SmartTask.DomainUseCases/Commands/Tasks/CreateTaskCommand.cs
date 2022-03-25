namespace SmartTask.DomainUseCases.Commands.Tasks;

public class CreateTaskCommand
{
    private readonly ITaskContext _context;

    public CreateTaskCommand(ITaskContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(SmartTask.Domain.Task newTask) =>
        throw new NotImplementedException();
}