using EmployeeManagement.API.Models;
using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeApiController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployeeById([FromRoute] int id)
        {
            try
            {

                return Ok(ToEmployeeDetailedViewModel(_employeeService.GetEmployeeById(id)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetEmployees()
        {
            try
            {
                return Ok(ToEmployeeViewModel(_employeeService.GetEmployees()));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost]
        [Route("insert")]

        public IActionResult InsertEmployee(EmployeeData employeeData)
        {
            try
            {
                return Ok(_employeeService.InsertEmployee(employeeData));

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateEmployee(EmployeeData employeeData)
        {
            try
            {
                return Ok(_employeeService.UpdateEmployee(employeeData));

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            try
            {
                return Ok(_employeeService.DeleteEmployee(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        

        private EmployeeDetailedViewModel ToEmployeeDetailedViewModel(EmployeeDto employee)
        {
            var employeeDetailedViewModel = new EmployeeDetailedViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department,
                Age = employee.Age,
                Address = employee.Address

            };
            return employeeDetailedViewModel;
        }
        private IEnumerable<EmployeeViewModel> ToEmployeeViewModel(IEnumerable<EmployeeDto> employeeDto)
        {
            var listOfEmployeeViewModel = new List<EmployeeViewModel>();
            foreach (var item in employeeDto)
            {
                listOfEmployeeViewModel.Add(new EmployeeViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Department = item.Department,
                    
                });
            
            }
            return listOfEmployeeViewModel;

        }
    }
}
