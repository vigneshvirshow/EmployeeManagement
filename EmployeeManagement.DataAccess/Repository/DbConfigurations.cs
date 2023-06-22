using EmployeeManagement.DataAccess.Contracts;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagement.DataAccess.Repository
{
    public class DbConfigurations : IDbConfigurations
    {

        private readonly IConfiguration _configuration;
        public DbConfigurations(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string ConnectionString 
        { 
            get
            {
            return _configuration.GetSection("ConnectionStrings").GetSection("MyConnectionString").Value;
            }
        } 
    }
}