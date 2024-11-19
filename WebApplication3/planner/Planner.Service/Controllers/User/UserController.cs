using AutoMapper;
using Planner.BL.User.Entities;
using Planner.BL.User.Manager;
using Planner.BL.User.Provider;
using Planner.Service.Controllers.User.Entities;
using Planner.Service.Validator.User;
using Microsoft.AspNetCore.Mvc;
using Planner.BL.User;
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
                    User = [UserModel]
                });
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
                return BadRequest(e.Message);
            }
        }
        _logger.Error(validationResult.toString());
        return BadRequest(validationResult.toString());
    }

    //тут будут ещё POST и GET!!
    
}