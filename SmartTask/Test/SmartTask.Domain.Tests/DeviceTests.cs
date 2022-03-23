using Xunit;

namespace SmartTask.Domain.Tests;

public class DeviceTests
{
    [Fact]
    public void TestConstructor()
    {
        const string expectedName = "testName";
        const string expectedAddress = "testAddress"; 
        
        var actual = new Device(expectedName, expectedAddress);
        
        Assert.Equal(expectedName, actual.Name);
        Assert.Equal(expectedAddress, actual.Address);
    }
}