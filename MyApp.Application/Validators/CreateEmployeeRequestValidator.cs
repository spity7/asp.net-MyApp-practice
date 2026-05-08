using FluentValidation;
using MyApp.Application.Dtos;

namespace MyApp.Application.Validators
{
    public sealed class CreateEmployeeRequestValidator : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeRequestValidator()
        {
            RuleFor(model => model.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(model => model.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(model => model.Phone)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
