using FluentValidation;
using KDWalks.API.Models.DTO;

namespace KDWalks.API.Validators
{
    public class AddWalkRequestValidators
        : AbstractValidator<AddWalkRequest>
    {
        public AddWalkRequestValidators()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(3)
                .WithMessage("Name must be at least 3 characters long.");

            RuleFor(x => x.Length)
                .GreaterThan(0)
                .WithMessage("Length must be greater than zero.");
        }
    }
}
