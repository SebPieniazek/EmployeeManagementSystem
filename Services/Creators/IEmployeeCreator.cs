using EmployeeManagementSystem.Models;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.Creators
{
    public interface IEmployeeCreator
    {

        public Task CreateEmployee(Employee employee);

    }
}
