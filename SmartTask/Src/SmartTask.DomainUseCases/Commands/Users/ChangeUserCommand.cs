using SmartTask.Domain;
using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Commands.Users;

public class ChangeUserCommand
{
    private readonly IUserContext _context;

    public ChangeUserCommand(IUserContext context) => _context = context;

    public async Task<User> ExecuteAsync(Guid userId, User changedUser) =>
        await _context.ChangeUser(userId, changedUser);
}
