using SmartTask.Domain;
using SmartTask.DomainUseCases.Commands.Categories;
using SmartTask.DomainUseCases.Contexts;
using SmartTask.DomainUseCases.Tests.FakeContexts;
using Xunit;

namespace SmartTask.DomainUseCases.Tests;

public class CategoriesUseCasesTests
{
    private readonly ICategoryContext _context;

    public CategoriesUseCasesTests()
    {
        _context = new FakeCategoryContext();
    }

    [Fact]
    public async void TestCategoryCrud()
    {
        var createdCategory = await TestCreateCategory();

        const string expectedChangedName = "changedCategoryName";

        var changedCategory = await new ChangeCategoryCommand(_context)
            .ExecuteAsync(
                createdCategory.Id,
                createdCategory with {Name = expectedChangedName});
        
        Assert.Equal(createdCategory.Id, changedCategory.Id);
        Assert.Equal(expectedChangedName, changedCategory.Name);

        var deletedCategoryResult = await new DeleteCategoryCommand(_context)
            .ExecuteAsync(createdCategory.Id);
        Assert.True(deletedCategoryResult >= 0);

        var deletedCategory = await _context.GetCategoryById(createdCategory.Id);
        Assert.Equal(deletedCategory, Category.Empty);
    }

    [Fact]
    public async Task<Category> TestCreateCategory()
    {
        const string expectedName = "testCategory";

        var createdCategoryId = await new CreateCategoryCommand(_context)
            .ExecuteAsync(new Category(expectedName));

        var createdCategory = await _context.GetCategoryById(createdCategoryId);
        
        Assert.Equal(expectedName, createdCategory.Name);

        return createdCategory;
    }
}