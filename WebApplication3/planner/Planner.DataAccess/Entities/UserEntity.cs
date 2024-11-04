using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DataAccess.Entities;

[Table("UserInfo")]

public class UserEntity : BaseEntity
{
    [Key]
    public int UserId { get; set; }
    //public string Role { get; set; }
    public string Role { get; set; }
    [ForeignKey("Role")]
    public virtual RoleEntity RoleName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}
