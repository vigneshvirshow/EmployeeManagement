﻿using EmployeeManagement.Application.Contracts;
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

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            return _employeeRepository.GetEmployees()?.Select(x => new EmployeeDto
            {
                Address = x.Address,
                Age = x.Age,
                Department = x.Department,
                Id = x.Id,
                Name = x.Name
            });
        }

        public EmployeeDto GetEmployeeById(int id)
        {
           return ToEmployeeDto(_employeeRepository.GetEmployeeById(id));
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
    }
}
