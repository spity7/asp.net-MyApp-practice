using FluentValidation;
using MyApp.Application.Commands;

namespace MyApp.Application.Validators
{
    public sealed class AddEmployeeCommandValidator : AbstractValidator<AddEmployeeCommand>
    {
        public AddEmployeeCommandValidator(CreateEmployeeRequestValidator inner)
        {
            RuleFor(command => command.Request).SetValidator(inner);
        }
    }
}
