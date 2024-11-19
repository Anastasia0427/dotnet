using Planner.BL.User.Entities;
namespace Planner.Service.Controllers.User.Entities;

public class UserListResponse
{
    public List<UserModel> Users { get; set; }
}