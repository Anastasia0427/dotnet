using Planner.BL.User.Entities;

namespace Planner.BL.User;

public interface IUserManager
{
    UserModel CreateUser(CreateUserModel model);
    void DeleteUser(int UserId);
    UserModel UpdateUser(int UserId, UpdateUserModel model);
}

