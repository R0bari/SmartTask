using System.Configuration;
using System.Data.Entity;
using SmartTask.MSSQL.Entities;
using Task = SmartTask.MSSQL.Entities.Task;
using TaskStatus = SmartTask.MSSQL.Entities.TaskStatus;

namespace SmartTask.MSSQL;

public class MsSqlContext : DbContext
{
    private static readonly string ConnectionString = 
        ConfigurationManager.ConnectionStrings["SmartTask"].ConnectionString;

    public MsSqlContext() : base(ConnectionString)
    {
    }

    public DbSet<Task> Tasks { get; set; }
    public DbSet<TaskCategory> TaskCategories { get; set; }
    public DbSet<TaskPriority> TaskPriorities { get; set; }
    public DbSet<TaskStatus> TaskStatuses { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Device> Devices { get; set; }

    public DbSet<Setting> Settings { get; set; }
    public DbSet<SettingType> SettingTypes { get; set; }
}
