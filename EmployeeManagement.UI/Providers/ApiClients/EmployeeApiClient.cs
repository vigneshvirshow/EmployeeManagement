using EmployeeManagement.Application.Models;
using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Models.Provider;
using EmployeeManagement.UI.Providers.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EmployeeManagement.UI.Providers.ApiClients
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly HttpClient _httpClient;

        public EmployeeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployee()
        {
            using (var response = _httpClient.GetAsync("https://localhost:44305/api/employee/get-all").Result)
            {
                var employee = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(response.Content.ReadAsStringAsync().Result);

                return employee ;
            }
        }

        

        public EmployeeDetailedViewModel GetEmployeeById(int id)
        {
            using (var response = _httpClient.GetAsync("https://localhost:44305/api/employee/"+ id).Result)
            {
                var employee = JsonConvert.DeserializeObject <EmployeeDetailedViewModel>(response.Content.ReadAsStringAsync().Result);

                return  employee;
            }

        }


        public bool InsertEmployee(EmployeeData employee)
        { 
            var stringContent = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            using (var response = _httpClient.PostAsync("https://localhost:44305/api/employee/insert", stringContent).Result) { response.Content.ReadAsStringAsync();
            return true; } 
        }


        
        public bool UpdateEmployee(EmployeeData employee)
        {
            
                var stringContent = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                using (var response = _httpClient.PutAsync("https://localhost:44305/api/employee/update", stringContent).Result)
                {
                    response.Content.ReadAsStringAsync();
                    return true;
                };
            
        }
        public bool DeleteEmployee(int id)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(id));
            using (var response = _httpClient.DeleteAsync("https://localhost:44305/api/employee/delete/" + id).Result)
            {
                return true;
            }
        }


       /* private IEnumerable<EmployeeViewModel> ToEmployeeViewModel(IEnumerable<EmployeeDto> employeeDto)
        {
            var employeeViewModel = new List<EmployeeViewModel>();
            foreach (var item in employeeViewModel)
            {
                employeeViewModel.Add(new EmployeeViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Department = item.Department

                });

            }
            return employeeViewModel;
        }

        private EmployeeData ToEmployeeData(EmployeeDetailedViewModel employeeDetailedViewModel)
        {
            var employeeData = new EmployeeData()
            {
                Id = employeeDetailedViewModel.Id,
                Name = employeeDetailedViewModel.Name,
                Age = employeeDetailedViewModel.Age,
                Address = employeeDetailedViewModel.Address,
                Department = employeeDetailedViewModel.Department,

            };
            return employeeData;

        }*/


    }
}
