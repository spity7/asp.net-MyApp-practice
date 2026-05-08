using MediatR;
using MyApp.Application.Dtos;
using MyApp.Application.Mapping;
using MyApp.Core.Entities;
using MyApp.Core.Interfaces;

namespace MyApp.Application.Commands
{
    public record AddEmployeeCommand(CreateEmployeeRequest Request) : IRequest<EmployeeDto>;

    public class AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<AddEmployeeCommand, EmployeeDto>
    {
        public async Task<EmployeeDto> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            EmployeeEntity created =
                await employeeRepository.AddEmployeeAsync(request.Request.ToNewEntity(), cancellationToken);

            return created.ToDto();
        }
    }
}
