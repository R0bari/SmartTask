using Xunit;

namespace SmartTask.Domain.Tests;

public class UserTests
{
    [Fact]
    public void TestConstructor()
    {
        const string expectedEmail = "test@email.com";
        var expectedCreateDate = DateTime.Now;
        var expectedTasks = new List<Task>
        {
            new Task(
                Guid.NewGuid(),
                "testText",
                TaskStatus.ToDo,
                TaskPriority.Medium,
                new Category("Products"),
                DateTime.Now)
        };
        var expectedDevices = new List<Device>
        {
            new Device("Test PC", "135.121.74.123")
        };
        var expectedSettings = new List<Setting>
        {
            new Setting(SettingType.BackgroundColor, "#333")
        };
        
        var actual = new User(
            expectedEmail,
            expectedCreateDate,
            expectedTasks,
            expectedDevices,
            expectedSettings);
        
        Assert.Equal(expectedEmail, actual.Email);
        Assert.Equal(expectedCreateDate, actual.CreateDate);
        Assert.Equal(expectedTasks, actual.Tasks);
        Assert.Equal(expectedDevices, actual.Devices);
        Assert.Equal(expectedSettings, actual.Settings);
    }
}
