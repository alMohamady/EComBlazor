using EComBlazor.lib.DTOs.Identity;
using FluentValidation;

namespace EComBlazor.Validations.Identity
{
    public class LogInUserValidator : AbstractValidator<LogInUser>
    {
        LogInUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email foramt");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
