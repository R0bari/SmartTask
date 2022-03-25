using System;

namespace SmartTask.Domain;

public record Task
{
    public Guid Id { get; }
    public string Text { get; }
    public TaskStatus Status { get; }
    public TaskPriority Priority { get; }
    public TaskCategory Category { get; }
    public DateTime DateTime { get; }
    
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
