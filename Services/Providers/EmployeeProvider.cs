using EmployeeManagementSystem.DbContexts;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.Providers
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly DbContextsFactory _dbContextsFactory;

        public EmployeeProvider(DbContextsFactory dbContextsFactory)
        {
            _dbContextsFactory = dbContextsFactory;
        }

        public Task<IEnumerable<Employee>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
