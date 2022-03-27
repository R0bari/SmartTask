using SmartTask.Domain;
using SmartTask.DomainUseCases.Contexts;

namespace SmartTask.DomainUseCases.Commands.Users;

public class CreateUserCommand
{
    private readonly IUserContext _context;

    public CreateUserCommand(IUserContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(User newUser) =>
        await _context.CreateUser(newUser);
}
