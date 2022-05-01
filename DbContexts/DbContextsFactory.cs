using EmployeeManagementSystem.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace EmployeeManagementSystem.DbContexts
{
    public class DbContextsFactory
    {
        private readonly string _connectionString;
        private readonly InternetConnectionChecker _internetConnectionChecker;

        public DbContextsFactory(string connectionString)
        {
            _internetConnectionChecker = new InternetConnectionChecker();

            _connectionString = connectionString;
        }

        public EMSContext CreateDbContext()
        {
            _internetConnectionChecker.CheckInternetConnection();
            
            DbContextOptions options = new DbContextOptionsBuilder().UseNpgsql(_connectionString).Options;

            return new EMSContext(options);
            
        }
    }
}
