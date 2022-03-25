namespace SmartTask.DomainUseCases.Commands.Users;

public class ChangeUserCommand
{
    private readonly ITaskContext _context;

    public ChangeUserCommand(ITaskContext context) => _context = context;

    public async Task<List<SmartTask.Domain.Task>> ExecuteAsync() =>
        throw new NotImplementedException();
}