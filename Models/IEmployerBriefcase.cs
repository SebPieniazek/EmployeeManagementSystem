using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public interface IEmployerBriefcase
    {
        public Employee EmployeeToEdit { get; set; }

        public Task<IEnumerable<Employee>> GetAllEmployees();
        public Task AddEmployee(Employee employee);
        public Task EditEmployee(Employee employee);
        public Task RemoveEmployee(Employee employee);
    }
}
