using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.DbContexts
{
    public class DbContextsFactory
    {
        private readonly string _connectionString;

        public DbContextsFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public EMSContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseNpgsql(_connectionString).Options;

            return new EMSContext(options);
        }
    }
}
