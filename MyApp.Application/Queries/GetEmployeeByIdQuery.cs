using MediatR;
using MyApp.Application.Dtos;
using MyApp.Application.Mapping;
using MyApp.Core.Entities;
using MyApp.Core.Interfaces;

namespace MyApp.Application.Queries
{
    public record GetEmployeeByIdQuery(Guid EmployeeId) : IRequest<EmployeeDto?>;

    public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto?>
    {
        public async Task<EmployeeDto?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            EmployeeEntity? entity =
                await employeeRepository.GetEmployeeByIdAsync(request.EmployeeId, cancellationToken);

            return entity?.ToDto();
        }
    }
}
