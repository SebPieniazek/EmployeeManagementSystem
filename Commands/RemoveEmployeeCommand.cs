using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagementSystem.Commands
{
    public class RemoveEmployeeCommand : AsyncCommandBase
    {
        private readonly EmployeeListingViewModel _employeeListingViewModel;
        private readonly EmployerBriefcase _employerBriefcase;

        public RemoveEmployeeCommand(EmployeeListingViewModel employeeListingViewModel, EmployerBriefcase employerBriefcase)
        {
            _employeeListingViewModel = employeeListingViewModel;
            _employerBriefcase = employerBriefcase;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _employerBriefcase.RemoveEmployee(_employeeListingViewModel.SelectedEmployee);
        }
    }
}
