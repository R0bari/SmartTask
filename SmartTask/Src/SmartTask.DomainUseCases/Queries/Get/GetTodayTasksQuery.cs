using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Queries.Get;

public class GetTodayTasksQuery
{
    private readonly DateTime _tomorrow = DateTime.Today.AddDays(1);
    private readonly IUserContext _context;

    public GetTodayTasksQuery(IUserContext context) => _context = context;
    
    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync(Guid userId) =>
        (await _context.GetUserTasks(userId)
            .ConfigureAwait(false))
        .Where(t => t.DateTime >= DateTime.Today && t.DateTime <= _tomorrow)
        .ToList();
}
