using MyApp.Core.Models;
using System.Net.Http.Json;

namespace MyApp.Infrastructure.Services
{
    public class MockiHttpClientService(HttpClient httpClient) : IMockiHttpClientService
    {
        public async Task<MockiData> GetData()
        {
            return await httpClient.GetFromJsonAsync<MockiData>("79a883ff-00ec-43cd-a9d6-efe5dcb13487");
        }
    }
}
