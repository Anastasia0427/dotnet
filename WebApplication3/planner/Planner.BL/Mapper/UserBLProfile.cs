using AutoMapper;
using Planner.BL.User.Entities;
using Planner.DataAccess.Entities;

namespace Planner.BL.Mapper;

public class UserBLProfile : Profile
{
    public UserBLProfile()
    {
        CreateMap<UserEntity, UserModel>()
            .ForMember(x => x.UserId, y => y.MapFrom(src => src.UserId));
        
        CreateMap<CreateUserModel, UserEntity>()
            .ForMember(x => x.UserId, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.CreationTime, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore())
            .ForMember(x => x.UserName, y => y.MapFrom(src => src.UserName))
            .ForMember(x => x.Email, y => y.MapFrom(src => src.Email))
            //а точно ли с ролью тут надо так поступать? или мб заигнорить
            .ForMember(x => x.Role, y => y.MapFrom(src => src.Role));
        
        CreateMap<UpdateUserModel, UserEntity>()
            .ForMember(x => x.UserId, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore())
            .ForMember(x => x.UserName, y => 
                y.PreCondition(src => src.UserName != null))
            .ForMember(x => x.Email, y =>
                y.PreCondition(src => src.Email != null))
            .ForMember(x => x.Role, y =>
                y.PreCondition(src => src.Role != null))
            .ForMember(x => x.PasswordHash, y =>
                y.PreCondition(src => src.PasswordHash != null));
        
        
    }
}