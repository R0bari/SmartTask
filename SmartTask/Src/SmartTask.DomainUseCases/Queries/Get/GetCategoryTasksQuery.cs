using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Queries.Get;

public class GetCategoryTasksQuery
{
    private readonly ITaskContext _context;

    public GetCategoryTasksQuery(ITaskContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync(TaskContextSpecification specification) =>
        throw new NotImplementedException();
}
