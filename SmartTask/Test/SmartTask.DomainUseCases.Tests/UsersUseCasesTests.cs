using Xunit;
using SmartTask.Domain;
using SmartTask.DomainUseCases.Commands.Users;
using SmartTask.DomainUseCases.Contexts;
using SmartTask.DomainUseCases.Tests.FakeContexts;
using Task = System.Threading.Tasks.Task;
using TaskStatus = SmartTask.Domain.TaskStatus;

namespace SmartTask.DomainUseCases.Tests;

public class UsersUseCasesTests
{
    private readonly IUserContext _context;
    public UsersUseCasesTests()
    {
        _context = new FakeUserContext();
    }
    
    [Fact]
    public async Task TestUserCrud()
    {
        var createdUser = await TestCreateUser();

        const string expectedChangedEmail = "changed@email.com";
        var expectedChangedCreateDate = DateTime.Today;

        var changedUser = await new ChangeUserCommand(_context)
            .ExecuteAsync(
                createdUser.Id,
                createdUser with
                {
                    Email = expectedChangedEmail,
                    CreateDate = expectedChangedCreateDate
                });
        
        Assert.Equal(createdUser.Id, changedUser.Id);
        Assert.Equal(expectedChangedEmail, changedUser.Email);
        Assert.Equal(expectedChangedCreateDate, changedUser.CreateDate);

        var deletedUserResult = await new DeleteUserCommand(_context)
            .ExecuteAsync(createdUser.Id);
        Assert.True(deletedUserResult >= 0);
    }

    private async Task<User> TestCreateUser()
    {
        const string expectedEmail = "test@email.com";
        var expectedCreateDate = DateTime.Now;
        var expectedTasks = new List<Domain.Task>
        {
            Domain.Task.Empty
        };
        var expectedDevices = new List<Device>
        {
            new Device("Test PC", "135.121.74.123")
        };
        var expectedSettings = new List<Setting>
        {
            new Setting(SettingType.BackgroundColor, "#333")
        };

        var createdUserId = await new CreateUserCommand(_context)
            .ExecuteAsync(new User(
                expectedEmail,
                expectedCreateDate,
                expectedTasks,
                expectedDevices,
                expectedSettings));

        var createdUser = await _context.GetUserById(createdUserId);
        
        Assert.Equal(expectedEmail, createdUser.Email);
        Assert.Equal(expectedCreateDate, createdUser.CreateDate);
        Assert.Equal(expectedTasks, createdUser.Tasks);
        Assert.Equal(expectedDevices, createdUser.Devices);
        Assert.Equal(expectedSettings, createdUser.Settings);

        return createdUser;
    }
}
