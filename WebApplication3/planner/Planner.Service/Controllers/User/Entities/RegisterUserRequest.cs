using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Planner.Service.Controllers.User.Entities;

public class RegisterUserRequest
{
    [Required, MinLength(3)]
    public string UserName { get; set; }
    [Required, MinLength(5)]
    public string PasswordHash { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    public string Role { get; set; }
}