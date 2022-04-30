using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Commands
{
    public class LoadEmployeesCommand : AsyncCommandBase
    {
        private readonly EmployeeListingViewModel _employeeListingViewModel;
        private readonly EmployerBriefcase _employerBriefcase;

        public LoadEmployeesCommand(EmployeeListingViewModel employeeListingViewModel, EmployerBriefcase employerBriefcase)
        {
            _employeeListingViewModel = employeeListingViewModel;
            _employerBriefcase = employerBriefcase;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _employeeListingViewModel.UpdateList(await _employerBriefcase.GetAllEmployees());
        }
    }
}
