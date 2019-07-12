using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
