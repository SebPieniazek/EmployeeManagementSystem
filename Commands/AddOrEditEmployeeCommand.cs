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
    public class AddOrEditEmployeeCommand : AsyncCommandBase
    {
        private readonly AddOrEditEmployeeViewModel _addOrEditEmployeeViewModel;
        private readonly EmployerBriefcase _employerBriefcase;

        public AddOrEditEmployeeCommand(AddOrEditEmployeeViewModel addOrEditEmployeeViewModel, EmployerBriefcase employerBriefcase)
        {
            _addOrEditEmployeeViewModel = addOrEditEmployeeViewModel;
            _employerBriefcase = employerBriefcase;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if(_addOrEditEmployeeViewModel.Employee == null)
            {
                await _employerBriefcase.AddEmployee(_addOrEditEmployeeViewModel.CreateEmployee(0));
                MessageBox.Show("git");
            }
            else
            {
                
            }
        }
    }
}
