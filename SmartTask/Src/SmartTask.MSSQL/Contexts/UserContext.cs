using System.Data.Entity;
using System.Data.Entity.Migrations;
using MapsterMapper;
using SmartTask.Domain;
using SmartTask.DomainUseCases.Contexts;
using Task = SmartTask.Domain.Task;

namespace SmartTask.MSSQL.Contexts;

public class UserContext : BaseContext, IUserContext
{
    private readonly IMapper _mapper = new Mapper();

    public async Task<User> GetUserById(Guid userId)
    {
        var foundUser = _mapper.Map<User>(await Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == userId)
            .ConfigureAwait(false));
        return _mapper.Map<User>(foundUser);
    }

    public async Task<Guid> CreateUser(User user)
    {
        var added = Users.Add(_mapper.Map<Entities.User>(user)) ?? _mapper.Map<Entities.User>(User.Empty);
        await SaveChangesAsync()
            .ConfigureAwait(false);
        return added.Id;
    }

    public async Task<User> ChangeUser(Guid id, User user)
    {
        var userToUpdate = user with {Id = id};
        Users.AddOrUpdate(_mapper.Map<Entities.User>(userToUpdate));
        await SaveChangesAsync()
            .ConfigureAwait(false);
        return userToUpdate;
    }

    public async Task<int> DeleteUser(Guid id)
    {
        var userToDelete = await GetUserById(id);
        if (userToDelete == User.Empty)
        {
            return -1;
        }

        Users.Remove(_mapper.Map<Entities.User>(userToDelete));
        return await SaveChangesAsync()
            .ConfigureAwait(false);
    }

    public async Task<List<Device>> GetUserDevices(Guid userId)
    {
        var userDevices = await Devices
            .AsNoTracking()
            .Where(d => d.UserId == userId)
            .ToListAsync()
            .ConfigureAwait(false);
        return _mapper.Map<List<Device>>(userDevices);
    }

    public async Task<List<Task>> GetUserTasks(Guid userId)
    {
        var userTasks = await Tasks
            .AsNoTracking()
            .Where(t => t.UserId == userId)
            .ToListAsync()
            .ConfigureAwait(false);
        return _mapper.Map<List<Task>>(userTasks);
    }

    public async Task<List<Category>> GetUserCategories(Guid userId)
    {
        var userTasks = await GetUserTasks(userId);
        return _mapper.Map<List<Category>>(
            userTasks
            .Select(t => t.Category)
            .Distinct());
    }
}
