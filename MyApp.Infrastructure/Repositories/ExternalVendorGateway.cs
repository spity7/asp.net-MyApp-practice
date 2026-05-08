using MyApp.Core.Interfaces;using MyApp.Core.Models;
using MyApp.Infrastructure.Services;

namespace MyApp.Infrastructure.Repositories
{
    public class ExternalVendorGateway(
        IMockiHttpClientService mockiHttpClientService,
        IJokeHttpClientService jokeHttpClientService)
        : IExternalVendorGateway
    {
        public Task<MockiData> GetMockiDataAsync(CancellationToken cancellationToken = default)
        {
            return mockiHttpClientService.GetDataAsync(cancellationToken);
        }

        public Task<JokeModel> GetJokeAsync(CancellationToken cancellationToken = default)
        {
            return jokeHttpClientService.GetDataAsync(cancellationToken);
        }
    }
}
