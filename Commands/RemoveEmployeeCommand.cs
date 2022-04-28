using EmployeeManagementSystem.Models;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Commands
{
    public class RemoveEmployeeCommand : AsyncCommandBase
    {
        private readonly EmployerBriefcase _employerBriefcase;

        public RemoveEmployeeCommand( EmployerBriefcase employerBriefcase)
        {
            _employerBriefcase = employerBriefcase;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _employerBriefcase.RemoveEmployee(_employerBriefcase.CurrentEmployee);
        }
    }
}
