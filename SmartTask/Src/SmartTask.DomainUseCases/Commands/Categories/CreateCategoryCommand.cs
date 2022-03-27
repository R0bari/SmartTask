using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Commands.Categories;

public class CreateCategoryCommand
{
    private readonly ICategoryContext _context;

    public CreateCategoryCommand(ICategoryContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(SmartTask.Domain.Task newTask) =>
        throw new NotImplementedException();
}
