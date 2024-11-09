using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DataAccess.Entities;

[Table("UserInfo")]

public class UserEntity : BaseEntity
{
    [Key]
    public int UserId { get; set; }
    
    [Required]
    public string Role { get; set; }
    
    [ForeignKey("Role")]
    public virtual RoleEntity RoleName { get; set; }
    
    [Required]
    public string UserName { get; set; }

    [EmailAddress]
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}
