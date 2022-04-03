using SmartTask.DomainUseCases.Contexts;
using TaskStatus = SmartTask.Domain.TaskStatus;

namespace SmartTask.DomainUseCases.Queries.Get;

public class GetUncompletedTasksQuery
{
    private readonly IUserContext _context;

    public GetUncompletedTasksQuery(IUserContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync(Guid userId) =>
        (await _context.GetUserTasks(userId)
            .ConfigureAwait(false))
        .Where(t => t.Status != TaskStatus.Done && t.DateTime < DateTime.Today)
        .ToList();
}
