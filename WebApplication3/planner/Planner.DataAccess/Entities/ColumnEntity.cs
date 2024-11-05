using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DataAccess.Entities;

[Table("ColumnInfo")]

public class ColumnEntity : BaseEntity
{
    [Key]
    public int ColumnId { get; set; }
    public int FKUserId { get; set; }
    [ForeignKey("FKUserId")]
    public virtual UserEntity UserId { get; set; }
    public int FKBoardId { get; set; }
    [ForeignKey("FKBoardId")]
    public virtual BoardEntity BoardId { get; set; }
    public string ColumnTitle { get; set; }
}