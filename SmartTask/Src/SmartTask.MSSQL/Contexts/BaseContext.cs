using System.Configuration;
using System.Data.Entity;
using SmartTask.MSSQL.Entities;
using Task = SmartTask.MSSQL.Entities.Task;
using TaskStatus = SmartTask.MSSQL.Entities.TaskStatus;

namespace SmartTask.MSSQL.Contexts;

public class BaseContext : DbContext
{
    protected static readonly string ConnectionString = 
        ConfigurationManager.ConnectionStrings["SmartTask"].ConnectionString;

    public BaseContext() : base(ConnectionString)
    {
    }

    protected DbSet<Task> Tasks { get; set; }
    protected DbSet<TaskCategory> TaskCategories { get; set; }
    protected DbSet<TaskPriority> TaskPriorities { get; set; }
    protected DbSet<TaskStatus> TaskStatuses { get; set; }
    
    protected DbSet<User> Users { get; set; }
    
    protected DbSet<Device> Devices { get; set; }

    protected DbSet<Setting> Settings { get; set; }
    protected DbSet<SettingType> SettingTypes { get; set; }
}
