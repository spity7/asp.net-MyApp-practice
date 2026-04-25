using MyApp.Core.Models;

namespace MyApp.Infrastructure.Services
{
    public interface IMockiHttpClientService
    {
        Task<MockiData> GetData();
    }
}
