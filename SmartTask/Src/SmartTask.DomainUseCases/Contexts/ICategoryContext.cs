using SmartTask.Domain;

namespace SmartTask.DomainUseCases.Contexts;

public interface ICategoryContext
{
    public Task<Category> GetCategoryById(Guid id);
    public Task<Guid> CreateCategory(Category newCategory);
    public Task<Category> ChangeCategory(Guid id, Category category);
    public Task<int> DeleteCategory(Guid id);
}