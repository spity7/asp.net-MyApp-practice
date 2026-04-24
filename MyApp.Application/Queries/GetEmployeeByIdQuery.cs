using MediatR;
using MyApp.Core.Entities;
using MyApp.Core.Interfaces;

namespace MyApp.Application.Queries
{
    public record GetEmployeeByIdQuery(Guid employeeId) : IRequest<EmployeeEntity>;

    public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<GetEmployeeByIdQuery, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetEmployeeByIdAsync(request.employeeId);
        }
    }

}
