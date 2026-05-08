using FluentValidation;
using MyApp.Application.Commands;

namespace MyApp.Application.Validators
{
    public sealed class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator(UpdateEmployeeRequestValidator inner)
        {
            RuleFor(command => command.EmployeeId)
                .NotEmpty();

            RuleFor(command => command.Request).SetValidator(inner);
        }
    }
}
