using MediatR;
using MyApp.Core.Interfaces;
using MyApp.Core.Models;

namespace MyApp.Application.Queries
{
    public record GetJokeQuery() : IRequest<JokeModel>;

    public class GetJokeQueryHandler(IExternalVendorGateway externalVendorGateway)
        : IRequestHandler<GetJokeQuery, JokeModel>
    {
        public Task<JokeModel> Handle(GetJokeQuery request, CancellationToken cancellationToken)
        {
            return externalVendorGateway.GetJokeAsync(cancellationToken);
        }
    }
}
