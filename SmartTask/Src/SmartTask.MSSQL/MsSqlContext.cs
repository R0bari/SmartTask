using System.Configuration;
using System.Data.Entity;
using SmartTask.MSSQL.Entities;

namespace SmartTask.MSSQL;

public class MsSqlContext : DbContext
{
    private static readonly string ConnectionString = 
        ConfigurationManager.ConnectionStrings["SmartTask"].ConnectionString;

    public MsSqlContext() : base(ConnectionString)
    {
    }

    public DbSet<Device> Devices { get; set; }
    public DbSet<User> Users { get; set; }
}