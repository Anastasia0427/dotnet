using Planner.BL.User.Entities;

namespace Planner.BL.User;

public interface IUserProvider
{
    IEnumerable<UserModel> GetUsers(UserModelFilter modelFilter = null);
    UserModel GetUserInfo(int UserId);
}