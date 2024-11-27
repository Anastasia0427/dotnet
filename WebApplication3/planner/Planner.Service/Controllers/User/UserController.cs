using AutoMapper;
using Planner.BL.User.Entities;
using Planner.BL.User.Manager;
using Planner.BL.User.Provider;
using Planner.Service.Controllers.User.Entities;
using Planner.Service.Validator.User;
using Microsoft.AspNetCore.Mvc;
using Planner.BL.User;
using Planner.BL.User.Exceptions;
using ILogger = Serilog.ILogger;

namespace Planner.Service.Controllers.User;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserManager _userManager;
    private readonly IUserProvider _userProvider;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public UserController(IUserManager userManager, IUserProvider userProvider,
        IMapper mapper, ILogger logger)
    {
        _userManager = userManager;
        _userProvider = userProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpPost]
    [Route("register")]
    public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
    {
        var validationResult = new RegisterUserRequestValidator().Validate(request);
        if (validationResult.IsValid)
        {
            var createUserModel = _mapper.Map<CreateUserModel>(request);
            try
            {
                var userModel = _userManager.CreateUser(createUserModel);
                return Ok(new UserListResponse
                {
                    //User = [UserModel]
                    User = new List<UserModel> { userModel }
                });
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
                return BadRequest(e.Message);
            }
        }
        _logger.Error(validationResult.ToString());
        return BadRequest(validationResult.ToString());
    }

    [HttpPost]
    [Route("update")]
    public IActionResult UpdateUser([FromBody] UpdateUserRequest request)
    {
        var validationResult = new UpdateUserRequestValidator().Validate(request);
        if (validationResult.IsValid)
        {
            var updateUserModel = _mapper.Map<UpdateUserModel>(request);
            try
            {
                var userModel = _userManager.UpdateUser(request.Id, updateUserModel);
                return Ok(new UserListResponse
                {
                    User = [userModel]
                });
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
                return BadRequest("упс! что-то пошло не так...");
            }
        }
        _logger.Error(validationResult.ToString());
        return BadRequest(validationResult.ToString());
    }

    [HttpDelete]
    [Route("delete")]
    public IActionResult DeleteUser([FromQuery] int userId)
    {
        try
        {
            _userManager.DeleteUser(userId);
            return Ok("профиль успешно удалён!");
        }
        catch (UserNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            _logger.Error(e.ToString());
            return BadRequest("упс! что-то пошло не так...");
        }
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        try
        {
            var users = _userProvider.GetUsers();
            return Ok(new UserListResponse
            {
                User = users.ToList()
            });
        }
        catch (Exception e)
        {
            _logger.Error(e.ToString());
            return BadRequest("упс! что-то пошло не так!");
        }
    }
    
    
}