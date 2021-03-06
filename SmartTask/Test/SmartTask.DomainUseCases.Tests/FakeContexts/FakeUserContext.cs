using SmartTask.Domain;
using SmartTask.DomainUseCases.Contexts;
using Task = System.Threading.Tasks.Task;

namespace SmartTask.DomainUseCases.Tests.FakeContexts;

public class FakeUserContext : IUserContext
{
    private readonly List<User> _users = new List<User>();

    public Task<User> GetUserById(Guid userId) =>
        Task.Run(() => _users.FirstOrDefault(user => user.Id == userId) ?? User.Empty);

    public Task<Guid> CreateUser(User user)
    {
        var addedUser = user with {Id = Guid.NewGuid()};
        _users.Add(addedUser);
        return Task.FromResult(addedUser.Id);
    }

    public Task<User> ChangeUser(Guid id, User user)
    {
        var foundUser = _users.FirstOrDefault(u => u.Id == id) ?? User.Empty;
        if (foundUser == User.Empty)
        {
            return Task.FromResult(User.Empty);
        }

        foundUser = user;

        return Task.FromResult(foundUser);
    }

    public Task<int> DeleteUser(Guid id)
    {
        var found = _users.FirstOrDefault(user => user.Id == id) ?? User.Empty;
        return found == User.Empty
            ? Task.FromResult(-1)
            : Task.FromResult(_users.RemoveAll(user => user.Id == id));
    }

    public Task<List<Device>> GetUserDevices(Guid userId) =>
        Task.FromResult(new List<Device>());

    public Task<List<Domain.Task>> GetUserTasks(Guid userId)
    {
        var user = _users.FirstOrDefault(user => user.Id == userId) ?? User.Empty;
        return Task.FromResult(
            user == User.Empty
                ? new List<Domain.Task>()
                : user.Tasks);
    }

    public async Task<List<Category>> GetUserCategories(Guid userId) =>
        (await GetUserTasks(userId))
            .Select(t => t.Category)
            .Distinct()
            .ToList();
}