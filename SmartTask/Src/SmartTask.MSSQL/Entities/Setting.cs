using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTask.MSSQL.Entities;

public class Setting
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public string Value { get; set; }
    
    [Required]
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    [Required]
    public Guid SettingTypeId { get; set; }
    public SettingType SettingType { get; set; }
    
}
