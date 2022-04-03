using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Queries.Get;

public class GetFutureTasksQuery
{
    private readonly DateTime _tomorrow = DateTime.Today.AddDays(1);
    private readonly IUserContext _context;

    public GetFutureTasksQuery(IUserContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync(Guid userId) =>
        (await _context.GetUserTasks(userId)
            .ConfigureAwait(false))
        .Where(t => t.DateTime >= _tomorrow)
        .ToList();
}