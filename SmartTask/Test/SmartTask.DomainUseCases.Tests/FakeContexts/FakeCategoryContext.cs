using SmartTask.Domain;
using SmartTask.DomainUseCases.Contexts;
using Task = System.Threading.Tasks.Task;

namespace SmartTask.DomainUseCases.Tests.FakeContexts;

public class FakeCategoryContext : ICategoryContext
{
    private readonly List<Category> _categories = new List<Category>();

    public Task<Category> GetCategoryById(Guid id) =>
        Task.Run(() => _categories.FirstOrDefault(c => c.Id == id) ?? Category.Empty);

    public Task<Guid> CreateCategory(Category newCategory)
    {
        var addedCategory = newCategory with {Id = Guid.NewGuid()};
        _categories.Add(addedCategory);
        return Task.FromResult(addedCategory.Id);
    }
    
    public Task<Category> ChangeCategory(Guid id, Category category)
    {
        var foundCategory = _categories.FirstOrDefault(c => c.Id == id) ?? Category.Empty;
        if (foundCategory == Category.Empty)
        {
            return Task.FromResult(Category.Empty);
        }

        foundCategory = category;
        
        return Task.FromResult(foundCategory);
    }

    public Task<int> DeleteCategory(Guid id)
    {
        var found = _categories.FirstOrDefault(c => c.Id == id) ?? Category.Empty;
        return found == Category.Empty
            ? Task.FromResult(-1)
            : Task.FromResult(_categories.RemoveAll(c => c.Id == id));
    }
}
