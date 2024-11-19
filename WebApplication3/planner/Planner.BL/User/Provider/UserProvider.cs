using AutoMapper;
using Planner.BL.User.Entities;
using Planner.BL.User.Exceptions;
using Planner.DataAccess.Entities;
//и тут себе напоминалку оставлю: подключить Repository.csproj к .sln–файлу!!
using Planner.Repository.Repository;

namespace Planner.BL.User.Provider;

public class UserProvider : IUserProvider
{
    private readonly IRepository<UserEntity> _userRepository;
    private readonly IMapper _mapper;

    public UserProvider(IRepository<UserEntity> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public IEnumerable<UserEntity> GetUsers()
    {
        //в разработке...
        //return _mapper.Map<IEnumerable<UserModel>>(users);
        return _userRepository.GetAll();
    }

    public UserModel GetUserInfo(int UserId)
    {
        var entity = _userRepository.GetById(UserId);
        if (entity == null)
        {
            throw new UserNotFoundException("ой! такого пользователя не существует...\n");
        }
        
        return _mapper.Map<UserModel>(entity);
    }
    
}