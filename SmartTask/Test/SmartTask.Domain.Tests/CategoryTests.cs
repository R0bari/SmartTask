using Xunit;

namespace SmartTask.Domain.Tests;

public class CategoryTests
{
    [Fact]
    public void TestConstructor()
    {
        const string expectedName = "testCategoryName";

        var actual = new Category(expectedName);
        
        Assert.Equal(expectedName, actual.Name);
    }
}