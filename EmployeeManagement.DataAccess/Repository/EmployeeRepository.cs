using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private SqlConnection _sqlConnection;

        public EmployeeRepository()
        {
            _sqlConnection = new SqlConnection("Data Source=192.168.0.128\\mssql2016;database=TestDB;user id = frontiersdev;password=frontiers;TrustServerCertificate=True");
        }

        public EmployeeData GetEmployeeById(int id)
        {
            
            try
            {
                _sqlConnection.Open();


                var sqlCommand = new SqlCommand(cmdText: "SELECT *FROM EmployeeDetails where Id = @id", _sqlConnection);
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
            finally
            {
                _sqlConnection.Close();
            }

        }

        public IEnumerable<EmployeeData> GetEmployees()
        {
            try
            {

                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "select *from EmployeeDetails", _sqlConnection);

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
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool InsertEmployee(EmployeeData employee)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "INSERT INTO EmployeeDetails(Name, Age, Department, Address) VALUES (@name, @age, @department, @address)", _sqlConnection);
               
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
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool UpdateEmployee(EmployeeData employee)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "UPDATE EmployeeDetails SET Name=@name, Department=@department, Age=@age, Address=@address where Id=@id", _sqlConnection);
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
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "DELETE FROM EmployeeDetails WHERE Id = @id", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", id);

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }


    }
}
