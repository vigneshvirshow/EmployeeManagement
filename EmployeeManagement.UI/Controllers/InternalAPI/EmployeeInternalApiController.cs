using EmployeeManagement.UI.Models.Provider;
using EmployeeManagement.UI.Providers.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeeManagement.UI.Controllers.InternalAPI
{
    [Route("api/internal/employee")]
    [ApiController]
    public class EmployeeInternalApiController : ControllerBase
    {
        private readonly IEmployeeApiClient _employeeApiClient;

        public EmployeeInternalApiController(IEmployeeApiClient employeeApiClient)
        {
            _employeeApiClient = employeeApiClient;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployeeById([FromRoute] int id)
        {
            try
            {

                return Ok(_employeeApiClient.GetEmployeeById(id));
            }
            catch (Exception )
            {

                throw;
            }

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            try
            {
                return Ok(_employeeApiClient.DeleteEmployee(id));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpPost]
        [Route("insert")]
        public IActionResult InsertEmployee(EmployeeData employee)
        {
            try
            {
                return Ok(_employeeApiClient.InsertEmployee(employee));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateEmployee(EmployeeData employee)
        {
            try
            {
                return Ok(_employeeApiClient.UpdateEmployee(employee));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }


}
