﻿using EmployeeManagement.UI.Providers.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeeManagement.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeApiClient _employeeApiClient;

        public EmployeeController(IEmployeeApiClient employeeApiClient)
        {
            this._employeeApiClient = employeeApiClient;
        }

        public  IActionResult Index()
        {
            try
            {
                return View(_employeeApiClient.GetAllEmployee());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /*private IEnumerable<EmployeeViewModel> ToEmployeeViewModel(IEnumerable<EmployeeData> listOfEmployeeData)
        {
            var listOfEmployeeViewModel = new List<EmployeeViewModel>();
            foreach (var item in listOfEmployeeData)
            {
                listOfEmployeeViewModel.Add(new EmployeeViewModel()
                {Id = item.Id,
                Name = item.Name,
                Department = item.Department ,
                });
            }
            return listOfEmployeeViewModel;
            
        }*/
    }
}
