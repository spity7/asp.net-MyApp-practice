using Microsoft.Extensions.Options;
using MyApp.Core.Exceptions;
using MyApp.Core.Models;
using MyApp.Core.Options;
using System.Net.Http.Json;

namespace MyApp.Infrastructure.Services
{
    public class JokeHttpClientService(HttpClient httpClient, IOptionsMonitor<JokeApiOptions> optionsMonitor)
        : IJokeHttpClientService
    {
        public async Task<JokeModel> GetDataAsync(CancellationToken cancellationToken = default)
        {
            JokeApiOptions opts = optionsMonitor.CurrentValue;

            string path = opts.RandomJokePath.TrimStart('/');

            JokeModel? result = await httpClient.GetFromJsonAsync<JokeModel>(path, cancellationToken);

            if (result is null)
            {
                throw new ExternalServiceException("Joke API returned no data.");
            }

            return result;
        }
    }
}
