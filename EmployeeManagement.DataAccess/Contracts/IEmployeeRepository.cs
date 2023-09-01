using EmployeeManagement.DataAccess.Models;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeData> GetEmployees();
        EmployeeData GetEmployeeById(int id);
        bool InsertEmployee(EmployeeData employee);
        bool DeleteEmployee(int id);
        bool UpdateEmployee(EmployeeData employee);
    }
}
