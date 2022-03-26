using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Commands.Tasks;

public class DeleteTaskCommand
{
    private readonly ITaskContext _context;

    public DeleteTaskCommand(ITaskContext context) => _context = context;

    public async Task<int> ExecuteAsync(Guid taskId) =>
        await _context.DeleteTask(taskId);
}
