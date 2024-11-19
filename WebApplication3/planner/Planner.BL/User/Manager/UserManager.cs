using AutoMapper;
using AutoMapper.Internal.Mappers;
using Planner.BL.User.Entities;
using Planner.BL.User.Exceptions;
using Planner.DataAccess.Entities;
//пересоздать бы этого товарища по-хорошему, да к .sln–файлу подключить.. в следующем коммите сделаю
using Planner.Repository.Repository;

namespace Planner.BL.User.Manager;

public class UserManager : IUserManager
{
    private readonly IRepository<UserEntity> _userRepository;
    private readonly IMapper _mapper;

    public UserManager(IRepository<UserEntity> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public UserModel CreateUser(CreateUserModel createModel)
    {
        var entity = _mapper.Map<UserEntity>(createModel);
        try
        {
            entity = _userRepository.Save(entity);
            return _mapper.Map<UserModel>(entity);
        }
        catch (Exception e)
        {
            throw new UserAlreadyExistsException("ошибка! пользователь с такими данными уже существует\n");
        }
    }

    public void DeleteUser(int UserId)
    {
        var entity = _userRepository.GetById(UserId);
        if (entity is null)
            throw new UserNotFoundException("ой! такого пользователя не существует...\n");
        _userRepository.Delete(entity);
    }

    //вот тут немного не уверена насчёт правильности этого всего
    public UserModel UpdateUser(int UserId)
    {
        var entity = _userRepository.GetById(UserId);
        if (entity is null)
            throw new UserNotFoundException("ой! такого пользователя не существует...\n");
        
        entity = _mapper.Map<UpdateUserModel, UserEntity>(updateModel, 
            opts => opts.AfterMap(
            (src, dest) =>
            {
                dest.UserId = entity.UserId;
                dest.CreationTime = entity.CreationTime;
                dest.ModificationTime = entity.ModificationTime;
                dest.PasswordHash = src.PasswordHash == null ? entity.PasswordHash : dest.PasswordHash;
                dest.Email = src.Email == null ? entity.Email : dest.Email;
                dest.Role = src.Role == null ? entity.Role : dest.Role;
            }));
        try
        {
            entity = _userRepository.Save(entity);
            return _mapper.Map<UserModel>(entity);
        }
        catch (Exception e)
        {
            throw new UserAlreadyExistsException("ошибка! пользователь с такими данными уже существует\n");
        }
    }
}