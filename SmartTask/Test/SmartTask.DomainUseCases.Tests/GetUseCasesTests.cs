using SmartTask.Domain;
using SmartTask.DomainUseCases.Contexts;
using SmartTask.DomainUseCases.Queries.Get;
using SmartTask.DomainUseCases.Tests.FakeContexts;
using Xunit;
using Task = System.Threading.Tasks.Task;
using TaskStatus = SmartTask.Domain.TaskStatus;

namespace SmartTask.DomainUseCases.Tests;

public class GetUseCasesTests
{
    private readonly ITaskContext _taskContext = new FakeTaskContext();
    private readonly IUserContext _userContext = new FakeUserContext();
    private readonly User user;

    public GetUseCasesTests()
    {
        user = new User(
            "short@email.com",
            DateTime.Now,
            PrepareTaskList(),
            new List<Device>(),
            new List<Setting>());
        user = user with {Id = _userContext.CreateUser(user).GetAwaiter().GetResult()};
    }

    private List<Domain.Task> PrepareTaskList() =>
        new List<Domain.Task>()
        {
            new Domain.Task(
                Guid.NewGuid(),
                "clean window",
                TaskStatus.ToDo,
                TaskPriority.Medium,
                new Category("Homework"),
                DateTime.Now),
            new Domain.Task(
                Guid.NewGuid(),
                "check if I cooked today",
                TaskStatus.InProgress,
                TaskPriority.High,
                new Category("Homework"),
                DateTime.Now),
            new Domain.Task(
                Guid.NewGuid(),
                "walk in the park",
                TaskStatus.Done,
                TaskPriority.Low,
                new Category("Outdoor"),
                DateTime.Today.Subtract(new TimeSpan(1, 0, 0, 0))),
            new Domain.Task(
                Guid.NewGuid(),
                "cook chicken",
                TaskStatus.InProgress,
                TaskPriority.Medium,
                new Category("Homework"),
                DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0))),
            new Domain.Task(
                Guid.NewGuid(),
                "cook chicken",
                TaskStatus.InProgress,
                TaskPriority.Medium,
                new Category("Homework"),
                DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0)))
        };

    [Fact]
    public async void GetCategoryTasks()
    {
        var specification = new TaskContextSpecification
        {
            UserId = user.Id,
            Category = new Category("Homework")
        };
        var categoryTasks = await new GetCategoryTasksQuery(_userContext)
            .ExecuteAsync(specification);
        
        Assert.Equal(4, categoryTasks.Count);
    }
    
    [Fact]
    public void GetCompletedTasks()
    {
        throw new NotImplementedException();
    }
    
    [Fact]
    public void GetFutureTasks()
    {
        throw new NotImplementedException();
    }
    
    
    [Fact]
    public void GetTodayTasks()
    {
        throw new NotImplementedException();
    }
    
    [Fact]
    public void GetTomorrowTasks()
    {
        throw new NotImplementedException();
    }
    
    [Fact]
    public void GetUncompletedTasks()
    {
        throw new NotImplementedException();
    }
}