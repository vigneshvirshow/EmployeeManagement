﻿using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConfigurations _dbConfigurations;

        public EmployeeRepository(IDbConfigurations dbConfigurations)
        {
            _dbConfigurations = dbConfigurations;
        }

        public IEnumerable<EmployeeData> GetEmployees()
        {
            try
            {
                var sqlConnection = new SqlConnection(_dbConfigurations.ConnectionString);
                sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: QueryConstants.EmployeeData.GetEmployeeData, sqlConnection);
                var sqlDataReader = sqlCommand.ExecuteReader();
                var listOfEmployee = new List<EmployeeData>();

                while (sqlDataReader.Read())
                {
                    listOfEmployee.Add(new EmployeeData()
                    {
                        Id = (int)sqlDataReader["Id"],
                        Name = (string)sqlDataReader["Name"],
                        Department = (string)sqlDataReader["Department"],
                        Age = (int)sqlDataReader["Age"],
                        Address = (string)sqlDataReader["Address"],
                    });
                }
                return listOfEmployee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public EmployeeData GetEmployeeById(int id)
        {
            try
            {
                var sqlConnection = new SqlConnection(_dbConfigurations.ConnectionString);
                sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: QueryConstants.EmployeeData.GetEmployeeById, sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", id);
                var sqlDataReader = sqlCommand.ExecuteReader();
                var employee = new EmployeeData();
                while (sqlDataReader.Read())
                {
                    employee.Id = (int)sqlDataReader["Id"];
                    employee.Name = (string)sqlDataReader["Name"];
                    employee.Department = (string)sqlDataReader["Department"];
                    employee.Age = (int)sqlDataReader["Age"];
                    employee.Address = (string)sqlDataReader["Address"];
                }
                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertEmployee(EmployeeData employee)
        {
            try
            {
                var sqlConnection = new SqlConnection(_dbConfigurations.ConnectionString);
                sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: QueryConstants.EmployeeData.InsertEmployee, sqlConnection);
                sqlCommand.Parameters.AddWithValue("name", employee.Name);
                sqlCommand.Parameters.AddWithValue("department", employee.Department);
                sqlCommand.Parameters.AddWithValue("age", employee.Age);
                sqlCommand.Parameters.AddWithValue("address", employee.Address);

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdateEmployee(EmployeeData employee)
        {
            try
            {
                var sqlConnection = new SqlConnection(_dbConfigurations.ConnectionString);
                sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: QueryConstants.EmployeeData.UpdateEmployee, sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", employee.Id);
                sqlCommand.Parameters.AddWithValue("name", employee.Name);
                sqlCommand.Parameters.AddWithValue("department", employee.Department);
                sqlCommand.Parameters.AddWithValue("age", employee.Age);
                sqlCommand.Parameters.AddWithValue("address", employee.Address);

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteEmployee(int id)
        {
            try
            {
                var sqlConnection = new SqlConnection(_dbConfigurations.ConnectionString);
                sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: QueryConstants.EmployeeData.DeleteEmployee, sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", id);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}