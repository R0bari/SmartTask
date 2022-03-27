using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Commands.Categories;

public class DeleteCategoryCommand
{
    private readonly ICategoryContext _context;

    public DeleteCategoryCommand(ICategoryContext context) => _context = context;

    public async Task<int> ExecuteAsync(Guid taskId) =>
        await _context.DeleteCategory(taskId);
}
