using Xunit;

namespace SmartTask.Domain.Tests;

public class SettingTests
{
    [Fact]
    public void TestConstructor()
    {
        const SettingType expectedSettingType = SettingType.BackgroundColor;
        const string expectedValue = "testValue";
        var expectedUser = PrepareUser();

        var actual = new Setting(expectedSettingType, expectedValue, expectedUser);
        
        Assert.Equal(expectedSettingType, actual.Type);
        Assert.Equal(expectedValue, actual.Value);
        Assert.Equal(expectedUser, actual.User);
    }

    private static User PrepareUser()
    {
        const string expectedEmail = "test@email.com";
        var expectedCreateDate = DateTime.Now;
        var expectedTasks = new List<Task>
        {
            new Task("testText", TaskStatus.ToDo, TaskPriority.Medium, DateTime.Now)
        };
        var expectedDevices = new List<Device>
        {
            new Device("Test PC", "135.121.74.123")
        };
        var expectedSettings = new List<Setting>();
        
        return new User(
            expectedEmail,
            expectedCreateDate,
            expectedTasks,
            expectedDevices,
            expectedSettings);
    }
}