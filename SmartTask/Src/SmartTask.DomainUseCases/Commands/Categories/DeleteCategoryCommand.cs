using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Commands.Categories;

public class DeleteCategoryCommand
{
    private readonly ITaskContext _context;

    public DeleteCategoryCommand(ITaskContext context) => _context = context;

    public async Task<int> ExecuteAsync(Guid taskId) =>
        throw new NotImplementedException();
}
