using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

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
            try
            {
                await _employerBriefcase.RemoveEmployee(_employeeListingViewModel.SelectedEmployee);
                _employeeListingViewModel.SelectedEmployee = null;
                _employerBriefcase.EmployeeToEdit = null;
                _employeeListingViewModel.LoadEmployeesCommand.Execute(null);
                MessageBox.Show("Successfully removed an employee", "Removed", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception e)
            {
                MessageBox.Show($"Failed {e.Message} ! Try again later.", "Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
}
    }
}
