using SmartTask.Domain;
using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Commands.Categories;

public class ChangeCategoryCommand
{
    private readonly ITaskContext _context;

    public ChangeCategoryCommand(ITaskContext context) => _context = context;

    public async Task<Domain.Task> ExecuteAsync(Guid taskId, TaskCategory newCategory) =>
        throw new NotImplementedException();
}
