using MyApp.Core.Models;

namespace MyApp.Core.Interfaces
{
    /// <summary>
    /// Retrieves data from external HTTP APIs (not a persistence repository).
    /// </summary>
    public interface IExternalVendorGateway
    {
        Task<MockiData> GetMockiDataAsync(CancellationToken cancellationToken = default);

        Task<JokeModel> GetJokeAsync(CancellationToken cancellationToken = default);
    }
}
