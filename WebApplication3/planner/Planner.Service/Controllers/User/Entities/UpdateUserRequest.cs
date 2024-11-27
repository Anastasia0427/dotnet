using System.ComponentModel.DataAnnotations;

namespace Planner.Service.Controllers.User.Entities;

public class UpdateUserRequest
{
    public int Id { get; set; }
    [MinLength(3)]
    public string? UserName { get; set; }
    [MinLength(5)]
    public string? PasswordHash { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? Role { get; set; }
}