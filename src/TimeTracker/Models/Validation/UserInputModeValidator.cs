using FluentValidation;

namespace TimeTracker.Models.Validation
{
    public class UserInputModelValidator : AbstractValidator<UserInputModel>
    {
        public UserInputModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .Length(1, 100);

            RuleFor(x => x.HourRate)
                .NotNull()
                .GreaterThan(0)
                .LessThan(1000);
        }
    }
}