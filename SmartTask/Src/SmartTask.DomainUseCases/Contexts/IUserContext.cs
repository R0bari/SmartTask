using SmartTask.Domain;

namespace SmartTask.DomainUseCases.Contexts;

public interface IUserContext
{
    /// <summary>
    /// Get user by id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    User GetUserById(Guid userId);

    /// <summary>
    /// Create user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Guid CreateUser(User user);

    /// <summary>
    /// Change user email, tasks, devices, settings
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    User ChangeUser(Guid id, User user);

    /// <summary>
    /// Delete user by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Returns value more or equal to 0, if deletion succeeded</returns>
    int DeleteTask(Guid id);
}
