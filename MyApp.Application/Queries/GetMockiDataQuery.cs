using MediatR;
using MyApp.Core.Interfaces;
using MyApp.Core.Models;

namespace MyApp.Application.Queries
{
    public record GetMockiDataQuery() : IRequest<MockiData>;

    public class GetMockiDataQueryHandler(IExternalVendorGateway externalVendorGateway)
        : IRequestHandler<GetMockiDataQuery, MockiData>
    {
        public Task<MockiData> Handle(GetMockiDataQuery request, CancellationToken cancellationToken)
        {
            return externalVendorGateway.GetMockiDataAsync(cancellationToken);
        }
    }
}
