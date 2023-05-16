using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Models;
using System.Collections.Generic;

namespace EmployeeManagement.Application.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees();
        EmployeeDto GetEmployeeById(int id);
        bool InsertEmployee(EmployeeData employee);
        bool UpdateEmployee(EmployeeData employee);
        bool DeleteEmployee(int id);
    }
}
