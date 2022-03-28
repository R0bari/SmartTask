using SmartTask.Domain;
using SmartTask.DomainUseCases.Contexts;
using Task = SmartTask.Domain.Task;

namespace SmartTask.DomainUseCases.Queries.Get;

public class GetCategoryTasksQuery
{
    private readonly IUserContext _context;

    public GetCategoryTasksQuery(IUserContext context) => _context = context;

    public async Task<List<Domain.Task>> ExecuteAsync(TaskContextSpecification specification)
    {
        var isEmpty = specification.UserId == Guid.Empty
                      ||
                      specification.Category != Category.Empty &&
                      (await _context.GetUserCategories(specification.UserId))
                      .FindAll(c => c.Name == specification.Category.Name).Count == 0;

        return !isEmpty
            ? (await _context.GetUserTasks(specification.UserId))
                .Where(t => t.Category.Name == specification.Category.Name)
                .ToList()
            : new List<Task>();
    }
}