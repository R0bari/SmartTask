using Xunit;

namespace SmartTask.Domain.Tests;


public class TaskTests
{
    [Fact]
    public void TestConstructor()
    {
        const string expectedText = "testText";
        const TaskStatus expectedStatus = TaskStatus.ToDo;
        const TaskPriority expectedPriority = TaskPriority.Medium;
        const TaskCategory expectedCategory = TaskCategory.Homework;
        var expectedDateTime = DateTime.Now;
        
        var actual = new Task(expectedText, expectedStatus, expectedPriority, expectedCategory, expectedDateTime);
        
        Assert.Equal(expectedText, actual.Text);
        Assert.Equal(expectedStatus, actual.Status);
        Assert.Equal(expectedPriority, actual.Priority);
        Assert.Equal(expectedCategory, actual.Category);
        Assert.Equal(expectedDateTime, actual.DateTime);
    }
}