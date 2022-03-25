namespace SmartTask.DomainUseCases.Commands.Categories;

public class DeleteCategoryCommand
{
    private readonly ITaskContext _context;

    public DeleteCategoryCommand(ITaskContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync() =>
        throw new NotImplementedException();
}