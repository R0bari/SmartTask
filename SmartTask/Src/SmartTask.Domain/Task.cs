using System;

namespace SmartTask.Domain;

public record Task
{
    public Guid Id { get; init; }
    public string Text { get; init; }
    public TaskStatus Status { get; init; }
    public TaskPriority Priority { get; init; }
    public TaskCategory Category { get; init; }
    public DateTime DateTime { get; init; }
    
    public static Task Empty =>
        new Task("", TaskStatus.None, TaskPriority.None, TaskCategory.None, DateTime.MinValue);
    
    public Task(
        string text,
        TaskStatus status,
        TaskPriority priority,
        TaskCategory category,
        DateTime dateTime)
    {
        Id = Guid.NewGuid();
        Text = text;
        Status = status;
        Priority = priority;
        Category = category;
        DateTime = dateTime;
    }

}
public enum TaskStatus { None, ToDo, InProgress, Done }
public enum TaskPriority { None, Low, Medium, High }
public enum TaskCategory { None, Products, Homework }
