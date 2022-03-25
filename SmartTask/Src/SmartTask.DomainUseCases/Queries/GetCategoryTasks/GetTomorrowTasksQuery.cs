namespace SmartTask.DomainUseCases.Queries.GetCategoryTasks;

public class GetTomorrowTasksQuery
{
    private readonly ITaskContext _context;

    public GetTomorrowTasksQuery(ITaskContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync(Guid user) =>
        throw new NotImplementedException();
}