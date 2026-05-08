using MyApp.Application.Dtos;
using MyApp.Core.Entities;

namespace MyApp.Application.Mapping
{
    internal static class EmployeeMapping
    {
        public static EmployeeDto ToDto(this EmployeeEntity entity)
        {
            return new EmployeeDto(entity.Id, entity.Name, entity.Email, entity.Phone);
        }

        public static EmployeeEntity ToNewEntity(this CreateEmployeeRequest request)
        {
            return new EmployeeEntity
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
            };
        }

        public static EmployeeEntity ToUpdateEntity(this UpdateEmployeeRequest request)
        {
            return new EmployeeEntity
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
            };
        }
    }
}
