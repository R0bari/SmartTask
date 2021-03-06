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
        const TaskStatus expectedChangedStatus = TaskStatus.InProgress;
        const TaskPriority expectedChangedPriority = TaskPriority.High;
        var expectedChangedCategory = new Category("Products");
        var expectedChangedDateTime = DateTime.Now.AddDays(1);

        var changedTask = await new ChangeTaskCommand(_context)
            .ExecuteAsync(
                createdTask.Id,
                createdTask with
                {
                    Text = expectedChangedText,
                    Status = expectedChangedStatus,
                    Priority = expectedChangedPriority,
                    Category = expectedChangedCategory,
                    DateTime = expectedChangedDateTime
                });

        Assert.Equal(createdTask.Id, changedTask.Id);
        Assert.Equal(expectedChangedText, changedTask.Text);
        Assert.Equal(expectedChangedStatus, changedTask.Status);
        Assert.Equal(expectedChangedPriority, changedTask.Priority);
        Assert.Equal(expectedChangedCategory, changedTask.Category);
        Assert.Equal(expectedChangedDateTime, changedTask.DateTime);

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
        const TaskStatus expectedStatus = TaskStatus.ToDo;
        const TaskPriority expectedPriority = TaskPriority.Medium;
        var expectedCategory = new Category("Homework");
        var expectedDateTime = DateTime.Now;

        var createdTaskId = await new CreateTaskCommand(_context)
            .ExecuteAsync(new Domain.Task(
                Guid.NewGuid(),
                expectedText,
                expectedStatus,
                expectedPriority,
                expectedCategory,
                expectedDateTime));

        var createdTask = await _context.GetTaskById(createdTaskId);

        Assert.Equal(expectedText, createdTask.Text);
        Assert.Equal(expectedStatus, createdTask.Status);
        Assert.Equal(expectedPriority, createdTask.Priority);
        Assert.Equal(expectedCategory, createdTask.Category);
        Assert.Equal(expectedDateTime, createdTask.DateTime);

        return createdTask;
    }
}
