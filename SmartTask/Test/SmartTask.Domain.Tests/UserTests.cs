using Xunit;

namespace SmartTask.Domain.Tests;

public class UserTests
{
    [Fact]
    public void TestConstructor()
    {
        const string expectedEmail = "test@email.com";
        var createDate = DateTime.Now;
        var tasks = new List<Task>
        {
            new Task(
                Guid.NewGuid(),
                "testText",
                new TaskStatus(Guid.NewGuid(), "ToDo"),
                new TaskPriority(Guid.NewGuid(), "Medium"),
                new Category("Products"),
                DateTime.Now)
        };
        var devices = new List<Device>
        {
            new Device("Test PC", "135.121.74.123")
        };
        var settings = new List<Setting>
        {
            new Setting(SettingType.BackgroundColor, "#333")
        };
        
        var actual = new User(
            expectedEmail,
            createDate,
            tasks,
            devices,
            settings);
        
        Assert.Equal(expectedEmail, actual.Email);
        Assert.Equal(createDate, actual.CreateDate);
        Assert.Equal(tasks, actual.Tasks);
        Assert.Equal(devices, actual.Devices);
        Assert.Equal(settings, actual.Settings);
    }
}
