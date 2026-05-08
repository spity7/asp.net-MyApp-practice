using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities;
using MyApp.Core.Interfaces;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories
{
    public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
    {
        public async Task<IEnumerable<EmployeeEntity>> GetEmployees(CancellationToken cancellationToken = default)
        {
            return await dbContext.Employees.ToListAsync(cancellationToken);
        }

        public async Task<EmployeeEntity?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity entity,
            CancellationToken cancellationToken = default)
        {
            entity.Id = Guid.NewGuid();
            dbContext.Employees.Add(entity);

            await dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<EmployeeEntity?> UpdateEmployeeAsync(Guid employeeId, EmployeeEntity entity,
            CancellationToken cancellationToken = default)
        {
            EmployeeEntity? employee =
                await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeId, cancellationToken);

            if (employee is null)
            {
                return null;
            }

            employee.Name = entity.Name;
            employee.Email = entity.Email;
            employee.Phone = entity.Phone;

            await dbContext.SaveChangesAsync(cancellationToken);

            return employee;
        }

        public async Task<bool> DeleteEmployeeAsync(Guid employeeId,
            CancellationToken cancellationToken = default)
        {
            EmployeeEntity? employee =
                await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeId, cancellationToken);

            if (employee is null)
            {
                return false;
            }

            dbContext.Employees.Remove(employee);

            return await dbContext.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
