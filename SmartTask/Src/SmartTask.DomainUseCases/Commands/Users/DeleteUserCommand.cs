using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Commands.Users;

public class DeleteUserCommand
{
    private readonly IUserContext _context;

    public DeleteUserCommand(IUserContext context) => _context = context;

    public async Task<int> ExecuteAsync(Guid userId) =>
        throw new NotImplementedException();
}
