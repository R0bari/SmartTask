namespace SmartTask.DomainUseCases.Queries.GetCategoryTasks;

public class GetUncompletedTasksQuery
{
    private readonly ITaskContext _context;

    public GetUncompletedTasksQuery(ITaskContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync(Guid user) =>
        throw new NotImplementedException();
}