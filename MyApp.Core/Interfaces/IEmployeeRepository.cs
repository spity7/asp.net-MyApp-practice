using MyApp.Core.Entities;

namespace MyApp.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetEmployees(CancellationToken cancellationToken = default);

        Task<EmployeeEntity?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity entity, CancellationToken cancellationToken = default);

        Task<EmployeeEntity?> UpdateEmployeeAsync(Guid employeeId, EmployeeEntity entity,
            CancellationToken cancellationToken = default);

        Task<bool> DeleteEmployeeAsync(Guid employeeId, CancellationToken cancellationToken = default);
    }
}
