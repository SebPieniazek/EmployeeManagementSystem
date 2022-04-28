using EmployeeManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.Providers
{
    public interface IEmployeeProvider
    {

        public Task<IEnumerable<Employee>> GetAllEmployees();

    }
}
