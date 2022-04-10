using Xunit;

namespace SmartTask.Domain.Tests;


public class TaskTests
{
    [Fact]
    public void TestConstructor()
    {
        const string expectedText = "testText";
        var status = new TaskStatus(Guid.NewGuid(), "ToDo");
        var priority = new TaskPriority(Guid.NewGuid(), "Medium");
        var category = new Category("Products");
        var dateTime = DateTime.Now;
        
        var actual = new Task(
            Guid.NewGuid(),
            expectedText,
            status,
            priority,
            category,
            dateTime);
        
        Assert.Equal(expectedText, actual.Text);
        Assert.Equal(status, actual.Status);
        Assert.Equal(priority, actual.Priority);
        Assert.Equal(category, actual.Category);
        Assert.Equal(dateTime, actual.DateTime);
    }
}
