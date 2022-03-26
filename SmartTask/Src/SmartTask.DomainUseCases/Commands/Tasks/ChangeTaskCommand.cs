using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Commands.Tasks;

public class ChangeTaskCommand
{
    private readonly ITaskContext _context;

    public ChangeTaskCommand(ITaskContext context) => _context = context;

    public async Task<SmartTask.Domain.Task> ExecuteAsync(Guid taskId, SmartTask.Domain.Task changedTask) =>
        await _context.ChangeTask(taskId, changedTask);
}
