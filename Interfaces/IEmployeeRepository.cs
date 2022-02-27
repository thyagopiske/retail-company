using RetailCompany.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailCompany.Interfaces
{
    public interface IEmployeeRepository
    {
        Task AddEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int employeeId);
        int CountAllNonAlocatedEmployees();
        IList<string> GetAllNonAllocatedEmployessLastName();
        IList<Employee> GetAllEmployees();
        IList<Employee> GetAllEmployeesWithStore();
    }
}
