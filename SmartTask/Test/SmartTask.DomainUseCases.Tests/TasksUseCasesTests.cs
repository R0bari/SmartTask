using Xunit;
using SmartTask.Domain;
using SmartTask.DomainUseCases.Commands.Tasks;
using SmartTask.DomainUseCases.Contexts;
using SmartTask.DomainUseCases.Tests.FakeContexts;
using Task = System.Threading.Tasks.Task;
using TaskStatus = SmartTask.Domain.TaskStatus;

namespace SmartTask.DomainUseCases.Tests;

public class TasksUseCasesTests
{
    private readonly ITaskContext _context;

    public TasksUseCasesTests()
    {
        _context = new FakeTaskContext();
    }

    [Fact]
    public async Task TestTaskCrud()
    {
        var createdTask = await TestCreateTask();
        
        const string expectedChangedText = "changedText";
        var changedStatus = new TaskStatus(Guid.NewGuid(), "InProgress");
        var changedPriority = new TaskPriority(Guid.NewGuid(), "High");
        var changedCategory = new Category("Products");
        var changedDateTime = DateTime.Now.AddDays(1);

        var changedTask = await new ChangeTaskCommand(_context)
            .ExecuteAsync(
                createdTask.Id,
                createdTask with
                {
                    Text = expectedChangedText,
                    Status = changedStatus,
                    Priority = changedPriority,
                    Category = changedCategory,
                    DateTime = changedDateTime
                });

        Assert.Equal(createdTask.Id, changedTask.Id);
        Assert.Equal(expectedChangedText, changedTask.Text);
        Assert.Equal(changedStatus, changedTask.Status);
        Assert.Equal(changedPriority, changedTask.Priority);
        Assert.Equal(changedCategory, changedTask.Category);
        Assert.Equal(changedDateTime, changedTask.DateTime);

        var deletedTaskResult = await new DeleteTaskCommand(_context)
            .ExecuteAsync(createdTask.Id);
        Assert.True(deletedTaskResult >= 0);

        var deletedTask = await _context.GetTaskById(createdTask.Id);
        Assert.Equal(deletedTask, Domain.Task.Empty);
    }

    [Fact]
    private async Task<Domain.Task> TestCreateTask()
    {
        const string expectedText = "testText";
        var status = new TaskStatus(Guid.NewGuid(), "ToDo");
        var priority = new TaskPriority(Guid.NewGuid(), "Medium");
        var category = new Category("Homework");
        var dateTime = DateTime.Now;

        var createdTaskId = await new CreateTaskCommand(_context)
            .ExecuteAsync(new Domain.Task(
                Guid.NewGuid(),
                expectedText,
                status,
                priority,
                category,
                dateTime));

        var createdTask = await _context.GetTaskById(createdTaskId);

        Assert.Equal(expectedText, createdTask.Text);
        Assert.Equal(status, createdTask.Status);
        Assert.Equal(priority, createdTask.Priority);
        Assert.Equal(category, createdTask.Category);
        Assert.Equal(dateTime, createdTask.DateTime);

        return createdTask;
    }
}
