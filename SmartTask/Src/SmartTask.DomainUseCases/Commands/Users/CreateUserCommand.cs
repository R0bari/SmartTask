namespace SmartTask.DomainUseCases.Commands.Users;

public class CreateUserCommand
{
    private readonly ITaskContext _context;

    public CreateUserCommand(ITaskContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync() =>
        throw new NotImplementedException();
}