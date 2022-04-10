using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTask.MSSQL.Entities;

public record Task
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    [Required]
    public string Text { get; set; }
    
    [Required]
    public Guid StatusId { get; set; }
    public TaskStatus TaskStatus { get; set; }
    
    [Required]
    public Guid PriorityId { get; set; }
    public TaskPriority TaskPriority { get; set; }
    
    [Required]
    public Guid CategoryId { get; set; }
    public TaskCategory Category { get; set; }
    
    [Required]
    public DateTime DateTime { get; set; }
}
