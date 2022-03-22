namespace SmartTask.Domain;

public record Task(
    Guid TaskId,
    string Text,
    TaskStatus Status,
    TaskPriority Priority,
    DateTime DateTime);
public enum TaskStatus { ToDo, InProgress, Done }
public enum TaskPriority { Low, Medium, High }
