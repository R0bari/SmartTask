namespace SmartTask.DomainUseCases.Commands.Categories;

public class ChangeCategoryCommand
{
    private readonly ITaskContext _context;

    public ChangeCategoryCommand(ITaskContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync() =>
        throw new NotImplementedException();
}
