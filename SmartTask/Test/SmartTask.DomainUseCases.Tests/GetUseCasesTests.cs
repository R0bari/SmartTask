using SmartTask.Domain;
using SmartTask.DomainUseCases.Contexts;
using SmartTask.DomainUseCases.Queries.Get;
using SmartTask.DomainUseCases.Tests.FakeContexts;
using Xunit;
using TaskStatus = SmartTask.Domain.TaskStatus;

namespace SmartTask.DomainUseCases.Tests;

public class GetUseCasesTests
{
    private readonly IUserContext _userContext = new FakeUserContext();
    private readonly User _user;

    public GetUseCasesTests()
    {
        _user = new User(
            "short@email.com",
            DateTime.Now,
            PrepareTaskList(),
            new List<Device>(),
            new List<Setting>());
        _user = _user with {Id = _userContext.CreateUser(_user).GetAwaiter().GetResult()};
    }

    private static List<Domain.Task> PrepareTaskList() =>
        new List<Domain.Task>()
        {
            new Domain.Task(
                Guid.NewGuid(),
                "clean window",
                new TaskStatus(Guid.NewGuid(), "ToDo"),
                new TaskPriority(Guid.NewGuid(), "Medium"),
                new Category("Homework"),
                DateTime.Now),
            new Domain.Task(
                Guid.NewGuid(),
                "check if I cooked today",
                new TaskStatus(Guid.NewGuid(), "InProgress"),
                new TaskPriority(Guid.NewGuid(), "High"),
                new Category("Homework"),
                DateTime.Now),
            new Domain.Task(
                Guid.NewGuid(),
                "walk in the park",
                new TaskStatus(Guid.NewGuid(), "Done"),
                new TaskPriority(Guid.NewGuid(), "Low"),
                new Category("Outdoor"),
                DateTime.Today.Subtract(new TimeSpan(1, 0, 0, 0))),
            new Domain.Task(
                Guid.NewGuid(),
                "walk in the park",
                new TaskStatus(Guid.NewGuid(), "InProgress"),
                new TaskPriority(Guid.NewGuid(), "Low"),
                new Category("Outdoor"),
                DateTime.Today.Subtract(new TimeSpan(0, 5, 0, 0))),
            new Domain.Task(
                Guid.NewGuid(),
                "cook chicken",
                new TaskStatus(Guid.NewGuid(), "InProgress"),
                new TaskPriority(Guid.NewGuid(), "Medium"),
                new Category("Homework"),
                DateTime.Today.AddDays(1).AddHours(2)),
            new Domain.Task(
                Guid.NewGuid(),
                "cook chicken",
                new TaskStatus(Guid.NewGuid(), "InProgress"),
                new TaskPriority(Guid.NewGuid(), "Medium"),
                new Category("Homework"),
                DateTime.Now.AddDays(2))
        };

    [Fact]
    public async void GetCategoryTasks()
    {
        var specification = new TaskContextSpecification
        {
            UserId = _user.Id,
            Category = new Category("Homework")
        };
        var categoryTasks = await new GetCategoryTasksQuery(_userContext)
            .ExecuteAsync(specification);
        
        Assert.Equal(4, categoryTasks.Count);
    }
    
    [Fact]
    public async void GetCompletedTasks()
    {
        var completedTasks = await new GetCompletedTasksQuery(_userContext)
            .ExecuteAsync(_user.Id);
        
        Assert.Single(completedTasks);
    }
    
    [Fact]
    public async void GetFutureTasks()
    {
        var futureTasks = await new GetFutureTasksQuery(_userContext)
            .ExecuteAsync(_user.Id);
        
        Assert.Equal(2, futureTasks.Count);
    }
    
    
    [Fact]
    public async void GetTodayTasks()
    {
        var todayTasks = await new GetTodayTasksQuery(_userContext)
            .ExecuteAsync(_user.Id);

        Assert.Equal(2, todayTasks.Count);
    }
    
    [Fact]
    public async void GetTomorrowTasks()
    {
        var tomorrowTasks = await new GetTomorrowTasksQuery(_userContext)
            .ExecuteAsync(_user.Id);

        Assert.Single(tomorrowTasks);
    }
    
    [Fact]
    public async void GetUncompletedTasks()
    {
        var tomorrowTasks = await new GetUncompletedTasksQuery(_userContext)
            .ExecuteAsync(_user.Id);

        Assert.Single(tomorrowTasks);
    }
}
