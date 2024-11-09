using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DataAccess.Entities;

[Table("Roles")]

public class RoleEntity : BaseEntity
{
    [Key]
    public string RoleName { get; set; }
    
    public string? RoleDescription { get; set; }
}