using SmartTask.Domain;
using TaskStatus = SmartTask.Domain.TaskStatus;

namespace SmartTask.DomainUseCases.Contexts;

public record TaskContextSpecification
{
    public Guid UserId { get; init; } = Guid.Empty;
    public string Text { get; init; } = "";
    public DateOnly MinDate { get; init; } = DateOnly.MinValue;
    public DateOnly MaxDate { get; init; } = DateOnly.MaxValue;
    public TaskStatus Status { get; init; } = TaskStatus.Empty;
    public TaskPriority Priority { get; init; } = TaskPriority.Empty;
    public Category Category { get; init; } = Category.Empty;
}

public interface ITaskContext
{
    /// <summary>
    /// Get user tasks for date, status, priority
    /// </summary>
    /// <param name="taskContext"></param>
    /// <returns></returns>
    Task<List<Domain.Task>> GetTasks(TaskContextSpecification taskContext);

    
    /// <summary>
    /// Get  user task by id
    /// </summary>
    /// <param name="taskId"></param>
    /// <returns></returns>
    Task<Domain.Task> GetTaskById(Guid taskId);

    /// <summary>
    /// Create task
    /// </summary>
    /// <param name="task"></param>
    /// <returns>Id of new task</retuns>
    Task<Guid> CreateTask(Domain.Task task);
    
    /// <summary>
    /// Change task text, date, status, priority
    /// </summary>
    /// <param name="id"></param>
    /// <param name="task"></param>
    /// <returns>Task after change</returns>
    Task<Domain.Task> ChangeTask(Guid id, Domain.Task task);
    
    /// <summary>
    /// Delete task by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Returns value more or equal to 0, if deletion succeeded</returns>
    Task<int> DeleteTask(Guid id);
}
