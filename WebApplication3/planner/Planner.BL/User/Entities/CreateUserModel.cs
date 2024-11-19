namespace Planner.BL.User.Entities;

public class CreateUserModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    //PasswordHash???
}