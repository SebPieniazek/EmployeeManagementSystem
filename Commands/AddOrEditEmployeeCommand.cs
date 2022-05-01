using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

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
            try
            {
                if (_addOrEditEmployeeViewModel.Employee == null)
                {
                    await _employerBriefcase.AddEmployee(_addOrEditEmployeeViewModel.CreateEmployee(0));
                    MessageBox.Show("Successfully added employee", "Added", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    await _employerBriefcase.EditEmployee(_addOrEditEmployeeViewModel.CreateEmployee(_addOrEditEmployeeViewModel.Employee.ID));
                    MessageBox.Show("Successfully edited an employee", "Edited", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show($"Failed {e.Message} ! Try again later.", "Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
