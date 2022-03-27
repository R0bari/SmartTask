using System;

namespace SmartTask.Domain;

public record Task
{
    public Guid Id { get; init; }
    public string Text { get; init; }
    public TaskStatus Status { get; init; }
    public TaskPriority Priority { get; init; }
    public Category Category { get; init; }
    public DateTime DateTime { get; init; }
    
    public static Task Empty =>
        new Task(Guid.Empty, "", TaskStatus.None, TaskPriority.None, Category.Empty, DateTime.MinValue);
    
    public Task(
        Guid id,
        string text,
        TaskStatus status,
        TaskPriority priority,
        Category category,
        DateTime dateTime)
    {
        Id = id;
        Text = text;
        Status = status;
        Priority = priority;
        Category = category;
        DateTime = dateTime;
    }

}
public enum TaskStatus { None, ToDo, InProgress, Done }
public enum TaskPriority { None, Low, Medium, High }
