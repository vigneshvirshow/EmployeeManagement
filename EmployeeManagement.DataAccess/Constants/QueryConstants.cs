namespace EmployeeManagement.DataAccess
{
   public class QueryConstants
    {
        public static class EmployeeData
        {
            public const string GetEmployeeData = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WITH(NOLOCK)" +
                                                  "WHERE TABLE_NAME = 'EmployeeDetails')" +
                                                  "BEGIN " +
                                                  "CREATE TABLE EmployeeDetails(" +
                                                  "Id INT IDENTITY(1,1) PRIMARY KEY," +
                                                  "Name VARCHAR(20)," +
                                                  "Age INT," +
                                                  "Department VARCHAR(20)," +
                                                  "Address VARCHAR(50))" +
                                                  "END " +
                                                  "SELECT * FROM EmployeeDetails WITH(NOLOCK)";

            public const string GetEmployeeById = "SELECT *FROM EmployeeDetails WHERE Id = @id";

            public const string InsertEmployee = "INSERT INTO EmployeeDetails" +
                                                 "(Name, Age, Department, Address)" +
                                                 " VALUES (@name, @age, @department, @address)";

            public const string UpdateEmployee = "UPDATE EmployeeDetails " +
                                                 "SET Name=@name, Department=@department, Age=@age, Address=@address " +
                                                 "WHERE Id=@id";

            public const string DeleteEmployee = "DELETE FROM EmployeeDetails WHERE Id = @id";
        }
    }
}
