using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Planner.Service.Controllers.User.Entities;

public class RegisterUserRequest
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    
    public string Email { get; set; }
    public string Role { get; set; }
}