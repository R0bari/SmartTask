namespace SmartTask.DomainUseCases.Queries.Get;

public class GetTomorrowTasksQuery
{
    private readonly ITaskContext _context;

    public GetTomorrowTasksQuery(ITaskContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync(Guid user) =>
        throw new NotImplementedException();
}