using SmartTask.Domain;
using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Commands.Categories;

public class ChangeCategoryCommand
{
    private readonly ICategoryContext _context;

    public ChangeCategoryCommand(ICategoryContext context) => _context = context;

    public async Task<Category> ExecuteAsync(Guid id, Category newCategory) =>
        await _context.ChangeCategory(id, newCategory);
}
