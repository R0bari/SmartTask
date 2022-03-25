namespace SmartTask.DomainUseCases.Queries.GetCategoryTasks;

public class GetFutureTasksQuery
{
    private readonly ITaskContext _context;

    public GetFutureTasksQuery(ITaskContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync(Guid user) =>
        throw new NotImplementedException();
}