using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DataAccess.Entities;

[Table("BoardInfo")]

public class BoardEntity : BaseEntity
{
    [Key]
    public int BoardId { get; set; }
    [Key]
    public int FKUserId { get; set; }
    [ForeignKey("FKUserId")]
    public virtual UserEntity UserId { get; set; }
    public string BoardTitle { get; set; }
    public string? BoardDescription { get; set; }
}