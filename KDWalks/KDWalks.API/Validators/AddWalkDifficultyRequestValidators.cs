using FluentValidation;

namespace KDWalks.API.Validators
{
    public class AddWalkDifficultyRequestValidators
        : AbstractValidator<Models.DTO.AddWalkDifficultyRequest>
    {
        public AddWalkDifficultyRequestValidators()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.")
                .MaximumLength(100).WithMessage("Code cannot exceed 100 characters.");
        }
    }
}
