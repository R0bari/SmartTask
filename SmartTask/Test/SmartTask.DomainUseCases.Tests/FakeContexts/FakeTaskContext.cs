using SmartTask.DomainUseCases.Contexts;
using Task = System.Threading.Tasks.Task;

namespace SmartTask.DomainUseCases.Tests.FakeContexts;

public class FakeTaskContext : ITaskContext
{
    private readonly List<Domain.Task> _tasks = new List<Domain.Task>();

    public Task<List<Domain.Task>> GetTasks(TaskContextSpecification taskContext)
    {
        var filteredTasks = _tasks;
        if (taskContext.UserId != Guid.Empty)
        {
            filteredTasks = filteredTasks
                .Where(task => task.Id == taskContext.UserId)
                .ToList();
        }

        if (taskContext.Text != "")
        {
            filteredTasks = filteredTasks
                .Where(task => task.Text.Contains(taskContext.Text))
                .ToList();
        }

        filteredTasks = filteredTasks
            .Where(task =>
                task.DateTime >= taskContext.MinDate.ToDateTime(TimeOnly.MinValue) &&
                task.DateTime <= taskContext.MaxDate.ToDateTime(TimeOnly.MaxValue))
            .ToList();

        if (taskContext.Status.Name != "None")
        {
            filteredTasks = filteredTasks
                .Where(task => task.Status == taskContext.Status)
                .ToList();
        }

        if (taskContext.Priority.Name != "None")
        {
            filteredTasks = filteredTasks
                .Where(task => task.Priority == taskContext.Priority)
                .ToList();
        }

        return Task.FromResult(filteredTasks);
    }

    public Task<Domain.Task> GetTaskById(Guid taskId) =>
        Task.Run(() => _tasks.FirstOrDefault(task => task.Id == taskId) ?? Domain.Task.Empty);

    public Task<Guid> CreateTask(Domain.Task task)
    {
        var addedTask = task with {Id = Guid.NewGuid()};
        _tasks.Add(addedTask);
        return Task.FromResult(addedTask.Id);
    }

    public Task<Domain.Task> ChangeTask(Guid id, Domain.Task task)
    {
        var foundTask = _tasks.FirstOrDefault(t => t.Id == id) ?? Domain.Task.Empty;
        if (foundTask == Domain.Task.Empty)
        {
            return Task.FromResult(Domain.Task.Empty);
        }

        foundTask = task;

        return Task.FromResult(foundTask);
    }

    public Task<int> DeleteTask(Guid id)
    {
        var found = _tasks.FirstOrDefault(t => t.Id == id) ?? Domain.Task.Empty;
        return found == Domain.Task.Empty
            ? Task.FromResult(-1)
            : Task.FromResult(_tasks.RemoveAll(task => task.Id == id));
    }
}
