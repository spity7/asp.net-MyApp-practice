using MediatR;
using MyApp.Application.Dtos;
using MyApp.Application.Mapping;
using MyApp.Core.Interfaces;

namespace MyApp.Application.Queries
{
    public record GetAllEmployeesQuery() : IRequest<IEnumerable<EmployeeDto>>;

    public class GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
    {
        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request,
            CancellationToken cancellationToken)
        {
            return (await employeeRepository.GetEmployees(cancellationToken)).Select(entity => entity.ToDto());
        }
    }
}
