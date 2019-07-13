using FluentValidation;

namespace TimeTracker.Models.Validation
{
    public class ClientInputModelValidator : AbstractValidator<ClientInputModel>
    {
        public ClientInputModelValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .Length(0, 100);
        }
    }
}