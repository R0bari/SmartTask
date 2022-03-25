using SmartTask.Domain;

namespace SmartTask.DomainUseCases.Commands.Users;

public class ChangeUserCommand
{
    private readonly ITaskContext _context;

    public ChangeUserCommand(ITaskContext context) => _context = context;

    public async Task<User> ExecuteAsync(Guid userId, User changedUser) =>
        throw new NotImplementedException();
}