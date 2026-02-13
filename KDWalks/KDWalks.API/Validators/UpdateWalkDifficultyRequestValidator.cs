using FluentValidation;
using KDWalks.API.Models.DTO;

namespace KDWalks.API.Validators
{
    public class UpdateWalkDifficultyRequestValidator
        : AbstractValidator<Models.DTO.UpdateWalkDifficultyRequest>
    {
        public UpdateWalkDifficultyRequestValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.")
                .MaximumLength(100)
                .WithMessage("Code cannot exceed 100 characters.");
        }
    }
}
