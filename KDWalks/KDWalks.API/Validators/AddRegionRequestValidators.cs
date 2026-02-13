using FluentValidation;
using KDWalks.API.Models.DTO;

namespace KDWalks.API.Validators
{
    public class AddRegionRequestValidators
        : AbstractValidator<AddRegionRequest>
    {
        public AddRegionRequestValidators()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.")
                .MaximumLength(10).WithMessage("Code must not exceed 10 characters.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.Area)
                .GreaterThan(0).WithMessage("Area must be greater than zero.");

            RuleFor(x => x.Population)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Population cannot be negative.");
        }
    }
}
