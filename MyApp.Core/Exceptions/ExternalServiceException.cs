namespace MyApp.Core.Exceptions
{
    public sealed class ExternalServiceException(string message, Exception? innerException = null)
        : InvalidOperationException(message, innerException);
}
