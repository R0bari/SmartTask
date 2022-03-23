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
        var expectedDateTime = DateTime.Now;
        
        var actual = new Task(expectedText, expectedStatus, expectedPriority, expectedDateTime);
        
        Assert.Equal(expectedText, actual.Text);
        Assert.Equal(expectedStatus, actual.Status);
        Assert.Equal(expectedPriority, actual.Priority);
        Assert.Equal(expectedDateTime, actual.DateTime);
    }
}