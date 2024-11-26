using FluentValidation;
using Planner.Service.Controllers.User.Entities;
using DateTime = System.DateTime;

namespace Planner.Service.Validator.User;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("id is required");
        
        RuleFor(x => x.UserName)
            .Matches(@"^[a-zA-Z0-9_\-\.]+$")
            .WithMessage("username is required");
        
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("email is required");
        
        //как бы сделать так, чтобы роль обновлялась при создании доски/разрешении доступа к ней другим пользователям
        //на администратора? такое, интересно, вообще реально?..
    }
}