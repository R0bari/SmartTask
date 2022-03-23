using Xunit;

namespace SmartTask.Domain.Tests;

public class SettingTests
{
    [Fact]
    public void TestConstructor()
    {
        const SettingType expectedSettingType = SettingType.BackgroundColor;
        const string expectedValue = "testValue";

        var actual = new Setting(expectedSettingType, expectedValue);
        
        Assert.Equal(expectedSettingType, actual.Type);
        Assert.Equal(expectedValue, actual.Value);
    }
}