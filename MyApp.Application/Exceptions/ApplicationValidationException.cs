namespace MyApp.Application.Exceptions
{
    /// <summary>
    /// Raised when FluentValidation discovers invalid input inside the Application layer.
    /// </summary>
    public sealed class ApplicationValidationException(IDictionary<string, string[]> failures) : Exception("One or more validation failures occurred.")
    {
        public IDictionary<string, string[]> Errors { get; } = failures;
    }
}
