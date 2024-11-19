namespace Planner.Service.Controllers.User.Entities;

public class UpdateUserRequest
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? PasswordHash { get; set; }
    
    public string? Email { get; set; }
    public string? Role { get; set; }
}