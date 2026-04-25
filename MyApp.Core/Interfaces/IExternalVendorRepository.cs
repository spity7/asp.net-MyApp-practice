using MyApp.Core.Models;

namespace MyApp.Core.Interfaces
{
    public interface IExternalVendorRepository
    {
        Task<MockiData> GetMockiDataAsync(CancellationToken cancellationToken = default);

        Task<JokeModel> GetJokeAsync(CancellationToken cancellationToken = default);
    }
}
