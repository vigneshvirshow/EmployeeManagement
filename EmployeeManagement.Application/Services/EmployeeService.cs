using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeDto GetEmployeeById(int id)
        {
       

           return ToEmployeeDto(_employeeRepository.GetEmployeeById(id));

        }
        
        public IEnumerable<EmployeeDto> GetEmployees()
        {
           return ToEmployeeDto( _employeeRepository.GetEmployees());
        }

        public bool InsertEmployee(EmployeeData employee)
        {

     
            return _employeeRepository.InsertEmployee(employee);
        }

        public bool UpdateEmployee(EmployeeData employee)
        {

            return _employeeRepository.UpdateEmployee(employee);

        }

        public bool DeleteEmployee(int id)
        {

            return _employeeRepository.DeleteEmployee(id);

        }


        private EmployeeDto ToEmployeeDto(EmployeeData employee)
        {
            var employeeDto = new EmployeeDto()
            {
                Id = employee.Id,
                Name=employee.Name,
                Department = employee.Department,
                Age = employee.Age,
                Address= employee.Address
                
            };
            return employeeDto;

        }

        private IEnumerable<EmployeeDto> ToEmployeeDto(IEnumerable<EmployeeData> employees)
        {
            var employeeDtoList = new List<EmployeeDto>();
            foreach ( var item in employees)
            {
                employeeDtoList.Add(new EmployeeDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Department = item.Department,
                    Age = item.Age,
                    Address = item.Address
                }) ;
            }
            return employeeDtoList;
        }

 

    }
}
