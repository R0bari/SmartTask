using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Queries.Get;

public class GetTomorrowTasksQuery
{
    private readonly DateTime _tomorrow = DateTime.Today.AddDays(1);
    private readonly DateTime _dateAfterTomorrow = DateTime.Today.AddDays(2);
    private readonly IUserContext _context;

    public GetTomorrowTasksQuery(IUserContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync(Guid userId) =>
        (await _context.GetUserTasks(userId)
            .ConfigureAwait(false))
        .Where(t => t.DateTime >= _tomorrow && t.DateTime <= _dateAfterTomorrow)
        .ToList();
}
