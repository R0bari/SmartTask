using SmartTask.Domain;
using SmartTask.DomainUseCases.Commands.Devices;
using SmartTask.DomainUseCases.Contexts;
using SmartTask.DomainUseCases.Tests.FakeContexts;
using Xunit;

namespace SmartTask.DomainUseCases.Tests;

public class DevicesUseCasesTests
{
    private readonly IDeviceContext _context = new FakeDeviceContext();
    
    [Fact]
    public async void TestChangeDevice()
    {
        var createdDevice = await TestCreateDevice();

        const string expectedChangedName = "changedDeviceName";
        const string expectedChangedAddress = "changedDeviceAddress";

        var changedDevice = await new ChangeDeviceCommand(_context)
            .ExecuteAsync(
                createdDevice.Id,
                createdDevice with {Name = expectedChangedName, Address = expectedChangedAddress});
        
        Assert.Equal(createdDevice.Id, changedDevice.Id);
        Assert.Equal(expectedChangedName, changedDevice.Name);
        Assert.Equal(expectedChangedAddress, changedDevice.Address);

        var deletedDeviceResult = await new DeleteDeviceCommand(_context)
            .ExecuteAsync(createdDevice.Id);
        Assert.True(deletedDeviceResult >= 0);

        var deletedDevice = await _context.GetDeviceById(createdDevice.Id);
        Assert.Equal(deletedDevice, Device.Empty);
    }

    [Fact]
    public async Task<Device> TestCreateDevice()
    {
        const string expectedName = "testName";
        const string expectedAddress = "testAddress";

        var createdDeviceId = await new CreateDeviceCommand(_context)
            .ExecuteAsync(new Device(expectedName, expectedAddress));

        var createdDevice = await _context.GetDeviceById(createdDeviceId);
        
        Assert.Equal(expectedName, createdDevice.Name);
        Assert.Equal(expectedAddress, createdDevice.Address);

        return createdDevice;
    }
}