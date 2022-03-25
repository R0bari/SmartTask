using SmartTask.Domain;
using Task = SmartTask.Domain.Task;
using TaskStatus = SmartTask.Domain.TaskStatus;

namespace SmartTask.DomainUseCases;

public record TaskContextSpecification
{
    public Guid UserId { get; init; } = Guid.Empty;
    public string Text { get; init; } = "";
    public DateOnly Date { get; init; } = DateOnly.MinValue;
    public TaskStatus Status { get; init; } = TaskStatus.None;
    public TaskPriority Priority { get; init; } = TaskPriority.None;
}

public interface ITaskContext
{
    /// <summary>
    /// Get user tasks for date, status, priority
    /// </summary>
    /// <param name="taskContext"></param>
    /// <returns></returns>
    List<Task> GetTasks(TaskContextSpecification taskContext);

    /// <summary>
    /// Create task
    /// </summary>
    /// <param name="task"></param>
    /// <returns>Id of new task</returns>
    Guid CreateTask(Task task);
    
    /// <summary>
    /// Change task text, date, status, priority
    /// </summary>
    /// <param name="id"></param>
    /// <param name="task"></param>
    /// <returns>Task after change</returns>
    Task ChangeTask(Guid id, Task task);
    
    /// <summary>
    /// Delete task by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Returns value more or equal to 0, if deletion succeeded</returns>
    int DeleteTask(Guid id);
}