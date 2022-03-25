using SmartTask.Domain;

namespace SmartTask.DomainUseCases.Commands.Categories;

public class ChangeCategoryCommand
{
    private readonly ITaskContext _context;

    public ChangeCategoryCommand(ITaskContext context) => _context = context;

    public async Task<SmartTask.Domain.Task> ExecuteAsync(Guid taskId, TaskCategory newCategory) =>
        throw new NotImplementedException();
}
