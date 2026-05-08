namespace MyApp.Application.Dtos
{
    public record EmployeeDto(Guid Id, string Name, string Email, string Phone);

    public sealed class CreateEmployeeRequest
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }

    public sealed class UpdateEmployeeRequest
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}
