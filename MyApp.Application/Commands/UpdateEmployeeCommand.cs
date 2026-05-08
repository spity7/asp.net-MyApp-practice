using MediatR;
using MyApp.Application.Dtos;
using MyApp.Application.Mapping;
using MyApp.Core.Entities;
using MyApp.Core.Interfaces;

namespace MyApp.Application.Commands
{
    public record UpdateEmployeeCommand(Guid EmployeeId, UpdateEmployeeRequest Request) : IRequest<EmployeeDto?>;

    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<UpdateEmployeeCommand, EmployeeDto?>
    {
        public async Task<EmployeeDto?> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            EmployeeEntity? updated = await employeeRepository.UpdateEmployeeAsync(request.EmployeeId,
                request.Request.ToUpdateEntity(), cancellationToken);

            return updated?.ToDto();
        }
    }
}
