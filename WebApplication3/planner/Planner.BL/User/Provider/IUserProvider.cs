using Planner.BL.User.Entities;

namespace Planner.BL.User.Provider;

public interface IUserProvider
{
    IEnumerable<UserModel> GetUsers(FilterUserModel modelFilter = null);
    UserModel GetUserInfo(int UserId);
}