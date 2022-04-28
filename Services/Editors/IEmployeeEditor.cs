using EmployeeManagementSystem.Models;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.Editors
{
    public interface IEmployeeEditor
    {

        public Task EditEmployee(Employee employee);

    }
}
