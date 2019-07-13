using FluentValidation;

namespace TimeTracker.Models.Validation
{
    public class ProjectInputModeValidator : AbstractValidator<ProjectInputModel>
    {
        public ProjectInputModeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(0, 100);
        }
    }
}