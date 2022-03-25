namespace SmartTask.DomainUseCases.Commands.Categories;

public class CreateCategoryCommand
{
    private readonly ITaskContext _context;

    public CreateCategoryCommand(ITaskContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync() =>
        throw new NotImplementedException();
}