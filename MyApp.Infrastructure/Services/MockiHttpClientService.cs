using Microsoft.Extensions.Options;
using MyApp.Core.Exceptions;
using MyApp.Core.Models;
using MyApp.Core.Options;
using System.Net.Http.Json;

namespace MyApp.Infrastructure.Services
{
    public class MockiHttpClientService(HttpClient httpClient, IOptionsMonitor<MockiApiOptions> optionsMonitor)
        : IMockiHttpClientService
    {
        public async Task<MockiData> GetDataAsync(CancellationToken cancellationToken = default)
        {
            MockiApiOptions opts = optionsMonitor.CurrentValue;

            MockiData? result =
                await httpClient.GetFromJsonAsync<MockiData>(opts.DataPath.TrimStart('/'), cancellationToken);

            if (result is null)
            {
                throw new ExternalServiceException("Mocki API returned no data.");
            }

            return result;
        }
    }
}
