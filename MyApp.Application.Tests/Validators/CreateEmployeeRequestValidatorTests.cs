using MyApp.Application.Dtos;
using MyApp.Application.Validators;
using Xunit;

namespace MyApp.Application.Tests.Validators;

public class CreateEmployeeRequestValidatorTests
{
    private readonly CreateEmployeeRequestValidator _validator = new();

    [Fact]
    public void Validates_invalid_email()
    {
        var request = new CreateEmployeeRequest { Name = "A", Email = "not-email", Phone = "123" };

        FluentValidation.Results.ValidationResult result = _validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CreateEmployeeRequest.Email));
    }

    [Fact]
    public void Validates_well_formed_request()
    {
        var request = new CreateEmployeeRequest
            { Name = "Jane", Email = "jane@example.com", Phone = "+1-555-0100" };

        FluentValidation.Results.ValidationResult result = _validator.Validate(request);

        Assert.True(result.IsValid);
    }
}
