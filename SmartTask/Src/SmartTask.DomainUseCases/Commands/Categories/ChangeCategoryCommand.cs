using SmartTask.Domain;
using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Commands.Categories;

public class ChangeCategoryCommand
{
    private readonly ICategoryContext _context;

    public ChangeCategoryCommand(ICategoryContext context) => _context = context;

    public async Task<Domain.Task> ExecuteAsync(Guid taskId, Category newCategory) =>
        throw new NotImplementedException();
}
