using Planner.BL.Auth.Entities;

namespace Planner.BL.Auth;

public interface IAuthProvider
{
    Task<TokensResponse> GetToken(string email, string password);
    //в разработке...
}