using AutoMapper;
using Planner.BL.User.Entities;
//using Planner.Service.Controllers.User.Entities;


namespace Planner.Service.Mapper;

public class UserServiceProfile
{
    CreateMap<RegisterUserRequest, CreateUserModel>();
    CreateMap<UpdateUserRequest, UpdateUserModel>();

}