namespace SmartTask.DomainUseCases.Queries.Get;

public class GetTodayTasksQuery
{
    private readonly ITaskContext _context;

    public GetTodayTasksQuery(ITaskContext context) => _context = context;
    
    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync(Guid userId) =>
        await Task.Run(() => _context.GetTasks(new TaskContextSpecification
        {
            UserId = userId
        }));
}