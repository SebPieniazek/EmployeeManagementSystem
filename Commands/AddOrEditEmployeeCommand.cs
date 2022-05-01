using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Commands
{
    public class AddOrEditEmployeeCommand : AsyncCommandBase
    {
        private readonly AddOrEditEmployeeViewModel _addOrEditEmployeeViewModel;
        private readonly IEmployerBriefcase _employerBriefcase;

        public AddOrEditEmployeeCommand(AddOrEditEmployeeViewModel addOrEditEmployeeViewModel, IEmployerBriefcase employerBriefcase)
        {
            _addOrEditEmployeeViewModel = addOrEditEmployeeViewModel;
            _employerBriefcase = employerBriefcase;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if(_addOrEditEmployeeViewModel.Employee == null)
            {
                await _employerBriefcase.AddEmployee(_addOrEditEmployeeViewModel.CreateEmployee(0));
            }
            else
            {
                await _employerBriefcase.EditEmployee(_addOrEditEmployeeViewModel.CreateEmployee(_addOrEditEmployeeViewModel.Employee.ID));
            }
        }
    }
}
