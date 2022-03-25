using SmartTask.Domain;

namespace SmartTask.DomainUseCases.Commands.Users;

public class CreateUserCommand
{
    private readonly ITaskContext _context;

    public CreateUserCommand(ITaskContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(User newUser) =>
        throw new NotImplementedException();
}