using MediatR;
using MyApp.Core.Interfaces;
using MyApp.Core.Models;

namespace MyApp.Application.Queries
{
    public record GetMockiDataQuery() : IRequest<MockiData>;

    public class GetMockiDataQueryHandler(IExternalVendorRepository externalVendorRepository) : IRequestHandler<GetMockiDataQuery, MockiData>
    {
        public async Task<MockiData> Handle(GetMockiDataQuery request, CancellationToken cancellationToken)
        {
            return await externalVendorRepository.GetMockiDataAsync(cancellationToken);
        }
    }
}
