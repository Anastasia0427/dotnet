using FluentValidation;
using Planner.Service.Controllers.User.Entities;

namespace Planner.Service.Validator.User;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .Matches(@"[a-zA-Z0-9_\-\.+]")
            .WithMessage("please enter a valid username\nthis field is required");
        
        RuleFor(x => x.PasswordHash)
            .NotEmpty()
            .WithMessage("please enter a strong password\nthis field is required");
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("please enter a valid email\nthis field is required");
        
        // а здесь, соответственно, было бы неплохо, чтобы роль автоматически заадвалась как ~обычный пользователь~
        
        // ещё было бы классно сделать разграничение по ролям относительно каждой доски, но это, наверное, непросто,
        // возможно, потребуется в целом пересмотр БД
        // так что пока пусть так, не знаю
        
    }
}