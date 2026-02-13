using FluentValidation;
using KDWalks.API.Models.DTO;

namespace KDWalks.API.Validators
{
    public class LoginRequestValidators
        : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidators()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");
        }
    }
}
