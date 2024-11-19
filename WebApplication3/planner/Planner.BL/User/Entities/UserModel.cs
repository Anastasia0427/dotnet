namespace Planner.BL.User.Entities;

public class UserModel
{
    public int UserId { get; set; }
    public string Role { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
}