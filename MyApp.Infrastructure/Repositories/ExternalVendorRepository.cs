using MyApp.Core.Interfaces;
using MyApp.Core.Models;
using MyApp.Infrastructure.Services;

namespace MyApp.Infrastructure.Repositories
{
    public class ExternalVendorRepository(IMockiHttpClientService mockiHttpClientService, IJokeHttpClientService jokeHttpClientService)
        : IExternalVendorRepository
    {
        public async Task<MockiData> GetMockiDataAsync(CancellationToken cancellationToken = default)
        {
            return await mockiHttpClientService.GetData();
        }

        public async Task<JokeModel> GetJokeAsync(CancellationToken cancellationToken = default)
        {
            return await jokeHttpClientService.GetData();
        }
    }
}
