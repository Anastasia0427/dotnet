using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DataAccess.Entities;

[Table("Urgency")]

public class UrgencyEntity : BaseEntity
{
    [Key]
    public string Urgency { get; set; }
    public string UrgencyColor { get; set; }
}
