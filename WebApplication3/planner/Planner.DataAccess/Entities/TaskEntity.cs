using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DataAccess.Entities;

[Table("TaskInfo")]

public class TaskEntity : BaseEntity
{
    [Key]
    public int TaskId { get; set; }
    
    public int FKColumnId { get; set; }
    [ForeignKey("FKColumnId")]
    public virtual ColumnEntity ColumnId { get; set; }
    public string TaskTitle { get; set; }
    public string TaskComplexity { get; set; }
    public DateTime? TaskDeadline { get; set; }
    public string? TaskUrgency { get; set; }
    [ForeignKey("TaskUrgency")]
    public virtual UrgencyEntity Urgency { get; set; }
    public string? TaskProgress { get; set; }
    public string? TaskDescription { get; set; }
}