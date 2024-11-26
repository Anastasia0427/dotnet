using AutoMapper;
using Planner.BL.User.Entities;
using Planner.BL.User.Exceptions;
using Planner.DataAccess.Entities;
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

    public IEnumerable<UserModel> GetUsers(FilterUserModel filter = null)
    {
        string? userNamePart = filter?.UserName;
        string? emailPart = filter?.Email;
        string? rolePart = filter?.Role;
        DateTime? creationTime = filter?.CreationTime;
        DateTime? modificationTime = filter?.ModificationTime;
        
        var users = _userRepository.GetAll(u => 
            (userNamePart == null || u.UserName.Contains(userNamePart)) &&
            (emailPart == null || u.Email.Contains(emailPart)) &&
            (rolePart == null || u.Role.Contains(rolePart)) &&
            (creationTime == null || u.CreationTime == creationTime) &&
            (modificationTime == null || u.ModificationTime == modificationTime));
        return _mapper.Map<IEnumerable<UserModel>>(users);
        
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