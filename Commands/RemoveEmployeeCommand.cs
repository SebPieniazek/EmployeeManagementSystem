using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Commands
{
    public class RemoveEmployeeCommand : AsyncCommandBase
    {
        private readonly EmployeeListingViewModel _employeeListingViewModel;
        private readonly IEmployerBriefcase _employerBriefcase;

        public RemoveEmployeeCommand(EmployeeListingViewModel employeeListingViewModel, IEmployerBriefcase employerBriefcase)
        {
            _employeeListingViewModel = employeeListingViewModel;
            _employerBriefcase = employerBriefcase;
        }

        public override async Task ExecuteAsync(object parameter)
        {    
            await _employerBriefcase.RemoveEmployee(_employerBriefcase.CurrentEmployee);
            _employeeListingViewModel.SelectedEmployee = null;
            _employerBriefcase.CurrentEmployee = null;
            _employeeListingViewModel.LoadEmployeesCommand.Execute(null);
        }
    }
}
